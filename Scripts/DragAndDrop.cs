using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
	private bool _mouseState;
	public GameObject Target;
	public Vector3 screenSpace;
	public Vector3 offset;
	public float turnSpeed = 100f;
	private float mZCoord;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		// Debug.Log(_mouseState);
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hitInfo;
			if (Target == GetClickedObject(out hitInfo))
			{

				_mouseState = true;
				screenSpace = Camera.main.WorldToScreenPoint(Target.transform.position);
				offset = Target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
			}
		}
		if (Input.GetMouseButtonUp(0))
		{
			_mouseState = false;
		}
		if (_mouseState)
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
			//keep track of the mouse position
			var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

			//convert the screen mouse position to world point and adjust with offset
			var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
			curPosition.y=12.0f; //set objects to ground level
			//update the position of the object in the world
			Target.transform.position = curPosition;
		}
	}


	GameObject GetClickedObject(out RaycastHit hit)
	{
		GameObject target = null;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
		{
			target = hit.collider.gameObject;
		}

		return target;
	}

	// Calcuates mouse position
	private Vector3 GetMouseWorldPos()
	{
		Vector3 mousePoint = Input.mousePosition;
		mousePoint.z = mZCoord;
		return Camera.main.ScreenToWorldPoint(mousePoint);
	}
}
