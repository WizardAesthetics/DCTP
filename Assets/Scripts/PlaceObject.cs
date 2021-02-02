using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{

    private Vector3 movePoint;
    private float mZCoord;
    public GameObject prefab; // This should be set within Unity to the objects that will be moved with cursor
    public float turnSpeed = 100f;

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
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            //movePoint = gameObject.transform.position - GetMouseWorldPos();

            Instantiate(prefab, transform.position, transform.rotation);
            Destroy(gameObject); // Destroy object following cursor
            Cursor.visible = true;
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
