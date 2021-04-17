/*
* Class wrote my Eastern Michigan Univerity Computer Science Department
* Team Lead: Krish Narayanan
* Authurs: Blake Johnson, Joesph Stone, Sauel Grone 
*/

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class ThirdPCam : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    public Transform playerBody;

    public float orthographicSizeMin;
    public float orthographicSizeMax;
    public float fovMin;
    public float fovMax;

    public float zoomSpeed;
    public float rotateSpeed = 0.1f;

    public Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    /*
    * Looking for what button is being push to either rotate zoom o
    */
    void Update()
    {
        if (Input.GetMouseButton(2)) //Allows user to rotate camera with middle mouse wheel
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, 60f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
        if (Input.GetKey(KeyCode.LeftShift)) //Allows user to rotate camera with left shift
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, 55f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }

        Zoom();
    }

    /*
     * Zooms in the cammera 
     */
    void Zoom()
    {
        if (cam.orthographic)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                cam.orthographicSize += zoomSpeed;
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                cam.orthographicSize -= zoomSpeed;
            }
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, orthographicSizeMin, orthographicSizeMax);
        }
        else
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                cam.fieldOfView += zoomSpeed;
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                cam.fieldOfView -= zoomSpeed;
            }
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, fovMin, fovMax);
        }
    }
}
