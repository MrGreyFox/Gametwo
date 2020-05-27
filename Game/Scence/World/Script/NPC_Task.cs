using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Task : MonoBehaviour
{
    public bool EndDialog;
    public GameObject Dialog_1;
    public GameObject Dialog_2;
    public Quest_Event QE;
    public bool Fin_Dialog;
    private bool onHide;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (QE.end_Quest_1 == true)
        {
            Fin_Dialog = true;

        }
        if (EndDialog == true)
        {
            Time.timeScale = 1;
            QE.Quest1 = true;
            Dialog_1.SetActive(false);
        }
        if (Fin_Dialog == true) {
            Time.timeScale = 1;
            QE.Quest1 = false;
            Dialog_1.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            if (Fin_Dialog == false)
            {


                Time.timeScale = 0;
                if (QE.end_Quest_1 == false)
                {
                    Dialog_1.SetActive(true);
                }
                else
                {
                    Dialog_2.SetActive(true);
                }
            }
            else
            {
                if (onHide == false)
                {


                    Dialog_2.SetActive(true);
                    onHide = true;
                }
                }
            }
    }
}
