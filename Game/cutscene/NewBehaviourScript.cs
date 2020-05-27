using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public MovieTexture texture;
    private bool isload = false;
    // Start is called before the first frame update
    void Start()
    {
        texture.loop = false;
        texture.Play();
    }

    void OnGUI()
    {
        if (!isload)
        {
            if (texture.isPlaying) GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
            else
            {
                Application.LoadLevel(1);
                isload = true;
            }
        }    
    }
}
