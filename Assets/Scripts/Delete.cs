using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    public string tag;
    private static ArrayList objectArrayReturn = new ArrayList();
    int num;


    public void DeleteObj(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        int size = gameObjects.Length - 1;
        GameObject.Destroy(gameObjects[size]);
        num = objectArrayReturn.Count;
        objectArrayReturn.RemoveAt(num-1);
    }

    public void setObjectArrayReturn(ArrayList objectArray)
    {
        objectArrayReturn = objectArray;
        num = objectArrayReturn.Count;
    }

    public ArrayList getObjectArrayReturn()
    {
        num = objectArrayReturn.Count;
        return objectArrayReturn;
    }

}
