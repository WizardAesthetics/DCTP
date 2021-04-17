/*
* Class wrote my Eastern Michigan Univerity Computer Science Department
* Team Lead: Krish Narayanan
* Authurs: Blake Johnson, Joesph Stone, Sauel Grone 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    private static ArrayList objectArrayReturn = new ArrayList();
    int num;

    public void DeleteObj(string tag)
    {

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        int size = gameObjects.Length - 1;

        if(gameObjects[size].layer ==9)
        {
            if(Counter.count >0)
                Counter.count--;
        }
       

        if (gameObjects[size].layer ==11)
        {
            PlaceObject.limitRouter.SetCount(1);
        }
            

        GameObject.Destroy(gameObjects[size]);
        num = objectArrayReturn.Count;
        objectArrayReturn.RemoveAt(num - 1);
    }


    public void SetObjectArrayReturn(ArrayList objectArray)
    {
        objectArrayReturn = objectArray;
        num = objectArrayReturn.Count;
    }


    public ArrayList GetObjectArrayReturn()
    {
        num = objectArrayReturn.Count;
        return objectArrayReturn;
    }

}
