using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_Game: MonoBehaviour
{
    public bool isload = false;
    private void Update()
    {
        if (isload == true)
        {
            Application.LoadLevel(2);
        }
    }
}