﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{

    private Vector3 movePoint;
    private float mZCoord;
    public GameObject prefab; // This should be set within Unity to the objects that will be moved with cursor
    public float turnSpeed = 100f;
    private BuildCity city = new BuildCity();
    private ArrayList lacationArray = new ArrayList();
    private Vector3 pos;
    private Vector3 mousePos;
    private float dis;
    private GameObject buildings;
    private ArrayList buildingsArray = new ArrayList();
    private Vector3 m_Size;
    // Configurations set before first frame
    void Start()
    {
        Cursor.visible = false; // Cursor invisible while placing objects
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        //movePoint = gameObject.transform.position - GetMouseWorldPos();
        transform.position = new Vector3(GetMouseWorldPos().x, transform.position.y, GetMouseWorldPos().z);
    }

    void Update()
    {
        // Position of cube will follow cursor
        transform.position = new Vector3(GetMouseWorldPos().x, transform.position.y, GetMouseWorldPos().z);

        // rotate counterclockwise
        if (Input.GetKey("q"))
        {
            transform.Rotate(Vector3.up * -turnSpeed * Time.deltaTime);
        }

        //rortate clockwise
        if (Input.GetKey("e"))
        {
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
        }


        // When mouse is clicked, static object will spawn
        if (Input.GetMouseButton(0))
        {
            lacationArray = city.getPosArray();
            buildingsArray = city.getBuildingsArray();

            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

            for (int i =0; i< lacationArray.Count; i++)
            {
                pos = (Vector3)lacationArray[i];
                buildings = (GameObject)buildingsArray[i];

                mousePos = GetMouseWorldPos();
                dis = Vector3.Distance(pos, mousePos); // Calculating Distance

                if (dis<100 )
                {
                    m_Size = buildings.GetComponent<BoxCollider>().size;
                    pos.y = m_Size.y - (prefab.GetComponent<BoxCollider>().size).y; 

                    Instantiate(prefab, pos, transform.rotation);
                    Destroy(gameObject); // Destroy object following cursor
                    Cursor.visible = true;
                    break;
                } 
            }

        }
    }

    // Calcuates mouse position
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }



}