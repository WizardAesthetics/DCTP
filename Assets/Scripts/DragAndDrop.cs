/*
* Class wrote my Eastern Michigan Univerity Computer Science Department
* Team Lead: Krish Narayanan
* Authurs: Blake Johnson, Joesph Stone, Sauel Grone 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
	public GameObject Target;
	public Vector3 screenSpace;
	public Vector3 offset;
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
	private static ArrayList objectArray = new ArrayList();

	/*
	 * Checking if a moviable object has been selected
	 * Currently not being used
	 */
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			RaycastHit hitInfo;
			if (Target == GetClickedObject(out hitInfo))
			{

				screenSpace = Camera.main.WorldToScreenPoint(Target.transform.position);
				offset = Target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
			}

			lacationArray = city.GetPosArray();
			buildingsArray = city.GetBuildingsArray();

			mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

			for (int i = 0; i < lacationArray.Count; i++)
			{
				pos = (Vector3)lacationArray[i];
				buildings = (GameObject)buildingsArray[i];

				mousePos = GetMouseWorldPos();
				dis = Vector3.Distance(pos, mousePos); // Calculating Distance
				if (dis < 100)
				{
					m_Size = buildings.GetComponent<BoxCollider>().size;
					pos.y = m_Size.y - (prefab.GetComponent<BoxCollider>().size).y;
					for (int j = 0; j < objectArray.Count; j++)
					{

						if (Vector3.Distance(pos, (Vector3)objectArray[j]) == 0 && prefab.layer == 12)
						{
							return;
						}

					}
					
				}
			}
		}
	}

	/*
	 * Gets the object that was selected
	 */
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
