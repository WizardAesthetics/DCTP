using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    public string tag;
    
    public void DeleteObj(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        int size = gameObjects.Length-1;
        GameObject.Destroy(gameObjects[size]);
    }
}
