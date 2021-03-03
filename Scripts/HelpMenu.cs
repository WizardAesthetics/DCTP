using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu: MonoBehaviour
{

    public bool HelpMenuUp = false;
    public GameObject HelpMenuUI;
    public GameObject MovementControl;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (HelpMenuUp)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        HelpMenuUI.SetActive(false);
        HelpMenuUp = false;
        MovementControl.GetComponent<ThirdPMovement>().enabled = true;
    }

    public void Pause()
    {
        HelpMenuUI.SetActive(true);
        HelpMenuUp = true;
        MovementControl.GetComponent<ThirdPMovement>().enabled = false;
    }

}
