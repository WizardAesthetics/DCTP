/* Controls spawning of objects in game when button in clicked
   Objects is then handled by 'PlaceObject.cs */

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SpawnBtnHandler : MonoBehaviour
{
	public GameObject blueprint;
	
	// Creates object when button is clicked
	public void SpawnObject(){
        Vector3 mousePos = Input.mousePosition;
        mousePos.z += 25.0f; // Position just above button (may need to adjust later)
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
		objectPos.y = 0.8f; // Y position right above the ground (may need to adjust)
        Instantiate(blueprint, objectPos, Quaternion.identity);
	}
	
}
