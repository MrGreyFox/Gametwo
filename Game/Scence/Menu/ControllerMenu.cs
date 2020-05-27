using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMenu : MonoBehaviour
{
    public GameObject buttonsMenu;
    public GameObject buttonsExit;
    public GameObject buttonsChose;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShowExitButtons()
    {
        buttonsMenu.SetActive(false);
        buttonsExit.SetActive(true);
    }
    public void BackInMenu()
    {
        buttonsMenu.SetActive(true);
        buttonsExit.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void NewGameLoadVstyp()
    {
        buttonsMenu.SetActive(false);
        buttonsChose.SetActive(true);
    }
    public void Lok()
    {
        Application.LoadLevel("VstypLok");
    }
    public void Roku()
    {
        Application.LoadLevel("VstypRoku");
    }
}
