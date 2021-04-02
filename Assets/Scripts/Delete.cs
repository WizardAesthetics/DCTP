using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    public string tag;
    private static ArrayList objectArrayReturn = new ArrayList();
    int num;
    private FieldOfViewBlue fieldOfView = new FieldOfViewBlue();
    private int count;
    public static bool isDeleted = false;



    public void DeleteObj(string tag)
    {
        isDeleted = false;

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        int size = gameObjects.Length - 1;

        if (gameObjects[size].layer == 9)
        {
            PlaceObject.limitRouter.setCount(1);
        }
        if(gameObjects[size].layer == 12)
        {
            if (Counter.count >0 && (gameObjects[size].GetComponent<FieldOfViewBlue>().visibleTargets.Count > 0))
                Counter.count = Counter.count - 1;
        }
       
        GameObject.Destroy(gameObjects[size]);
        num = objectArrayReturn.Count;
        objectArrayReturn.RemoveAt(num - 1);
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
