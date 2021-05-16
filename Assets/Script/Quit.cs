using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public GameObject panelYesNo;
   
    public void Yes()
    {
        Application.Quit();
    }
    public void No()
    {
        panelYesNo.SetActive(false);
    }
    public void quitButton()
    {
        panelYesNo.SetActive(true);
    }
   
}
