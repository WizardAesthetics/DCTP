/* This script controls movement, rotation, and zooming

  of camera while in third person */


using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class ThirdPMovement : MonoBehaviour
{
    public float orthographicSizeMin;
    public float orthographicSizeMax;
    public float fovMin;
    public float fovMax;

    public float moveSpeed;
    public float zoomSpeed;
    public float rotateSpeed = 0.1f;


    Vector2 p1;
    Vector2 p2;

    public Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }


    // Update is called once per frame

    void Update()
    {
        // Actual movement
        Move();
        Rotate();
        Zoom();
    }

    // Movement with WASD keys
    void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        transform.position += new Vector3(xInput * moveSpeed * Time.deltaTime, 0f, zInput * moveSpeed * Time.deltaTime);
    }

    // Uses middle mouse scroll button to rotate screen
    void Rotate()
    {
        if (Input.GetMouseButtonDown(2))
        {
            p1 = Input.mousePosition;
        }

        if (Input.GetMouseButton(2))
        {
            p2 = Input.mousePosition;
            float dx = (p2 - p1).x * rotateSpeed * Time.deltaTime;
            float dy = (p2 - p1).y * rotateSpeed * Time.deltaTime;
            transform.rotation *= Quaternion.Euler(new Vector3(0, dx, 0));
        }
    }


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
