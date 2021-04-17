/*
* Class wrote my Eastern Michigan Univerity Computer Science Department
* Team Lead: Krish Narayanan
* Authurs: Blake Johnson, Joesph Stone, Sauel Grone 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu: MonoBehaviour
{

    public bool HelpMenuUp = false;
    public GameObject HelpMenuUI;
    public GameObject MovementControl;

    /*
    * Constantly checcking if the Escape was pressed
    */
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

    /*
     * Reusemes time and gets ride of help menu
     */
    public void Resume()
    {
        HelpMenuUI.SetActive(false);
        HelpMenuUp = false;
        Time.timeScale = 1;
    }

    /*
    * Stops time and brings up pause menu
    */
    public void Pause()
    {
        HelpMenuUI.SetActive(true);
        HelpMenuUp = true;
        Time.timeScale = 0;
    }

}
