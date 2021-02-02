/* This script should execute when the button to move to the previous level is pressed*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrevScene : MonoBehaviour
{
    public void BtnNewScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

}
