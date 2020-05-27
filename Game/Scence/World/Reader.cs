using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reader : MonoBehaviour
{
    public LayerMask mask;
    private bool isread = false;
    private Transform letter;
    public float rayDistance;
   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isread)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(transform.position, ray.direction * rayDistance);
            RaycastHit[] hits;
            hits = Physics.RaycastAll(ray, rayDistance);
            {
                foreach (RaycastHit hit in hits)
                if (hit.collider.tag == "letter")
                {
                        if (Input.GetKeyDown(KeyCode.E))
                    {
                        letter = hit.transform;
                        isread = true;
                    }
                }
            }
        }
        else
        {
            letter.position = Camera.main.transform.position + Camera.main.transform.forward * .5f;
            letter.LookAt(Camera.main.transform);
            if (Input.GetKeyDown(KeyCode.E))
            {
                isread = false;
                //Destroy(letter.gameObject);
            }
        }
    }
}
