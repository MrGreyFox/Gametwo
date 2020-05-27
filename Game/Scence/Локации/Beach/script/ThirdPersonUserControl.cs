using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

    public class ThirdPersonUserControl : MonoBehaviour
    {
        public GameObject Player;
        public GameObject Ragdoll;
        public Slider slider;
        private ThirdPersonCharacter m_Character; 
        private Transform m_Cam;                  
        private Vector3 m_CamForward;             
        private Vector3 m_Move;
        private bool m_Jump;                   
        public int health;

        
        private void Start()
        {
            slider.maxValue = slider.value = health;
            
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                
            }

            
            m_Character = GetComponent<ThirdPersonCharacter>();
        }

        public void addHealth(int count)
        {
            health += count;
            if (health > 200)
                health = 200;
        }
        public void minusHealth(int count)
        {
            health -= count;
        }

        private void Update()
        {
            slider.value = health;
            if (Input.GetKeyDown(KeyCode.H))
            {
                health -= 10;
                slider.value = health;
                if(health<=0)
                {
                    Player.SetActive(false);
                    Ragdoll.SetActive(true);
                    Instantiate(Ragdoll, transform.position, transform.rotation);
                }
            }
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        
        private void FixedUpdate()
        {
           
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            bool crouch = Input.GetKey(KeyCode.C);

            
            if (m_Cam != null)
            {
                
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v*m_CamForward + h*m_Cam.right;
            }
            else
            {
                
                m_Move = v*Vector3.forward + h*Vector3.right;
            }
#if !MOBILE_INPUT
			
	        if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;
        }
    }

