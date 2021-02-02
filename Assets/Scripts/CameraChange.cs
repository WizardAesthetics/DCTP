/* This script will change the view of the player between first and third person
   Change the view by pressing 'c' */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject ThirdCam;
    public GameObject FirstCam;
    public GameObject menu;
    public int CamMode;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Camera")){
            if (CamMode == 1)
            {
                CamMode = 0;
            } else
            {
                CamMode += 1;
            }
            StartCoroutine(CamChange());
        }
    }

    IEnumerator CamChange()
    {
        yield return new WaitForSeconds(0.01f);
        if (CamMode == 0)
        {
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
            menu.SetActive(false);
            ThirdCam.SetActive(true);
            FirstCam.SetActive(false);
        }
        if (CamMode == 1)
        {
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
            menu.SetActive(true);
            ThirdCam.SetActive(false);
            FirstCam.SetActive(true);
        }
    }
}
