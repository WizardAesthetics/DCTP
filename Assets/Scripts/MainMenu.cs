/*
* Class wrote my Eastern Michigan Univerity Computer Science Department
* Team Lead: Krish Narayanan
* Authurs: Blake Johnson, Joesph Stone, Sauel Grone 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /*
     * Start the game and loades in level one
     */
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /*
     * Used to get for Win scene back to the main menu
     */
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
