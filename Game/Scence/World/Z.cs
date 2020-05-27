using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Z : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    GameObject player;

    public float visible = 8f;
    public float angleV = 70f;
    public GameObject Zomb;
    public GameObject ZombRag;
    public int hp_z = 100;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < 1.5f)
            {
                animator.SetBool("attack", true);
                //Destroy(player);
            }
            else if (distance < visible)
            {
                Quaternion look = Quaternion.LookRotation(player.transform.position - transform.position);
                float angle = Quaternion.Angle(transform.rotation, look);
                if (angle < angleV)
                {
                    RaycastHit hit;
                    Ray ray = new Ray(transform.position + Vector3.up, player.transform.position - transform.position + Vector3.up);
                    if (Physics.Raycast(ray, out hit, visible))
                    {
                        if (hit.transform.gameObject == player)
                        {
                            agent.destination = player.transform.position;
                        }
                    }
                    
                }
            }
        }
        else
        {
            animator.SetBool("attack", false);
        }
        if (agent.velocity.magnitude > 2f)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "M_Attack")
        {
            hp_z = hp_z - 20;
            if (hp_z <= 0)
            {
                Zomb.SetActive(false);
                ZombRag.SetActive(true);
                Instantiate(ZombRag, transform.position, transform.rotation);
            }
        }
    }
}