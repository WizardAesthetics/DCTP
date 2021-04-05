using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{

    public static int count;
    private int number;
    private int number2;



    public int getCount()
    {
        return count;
    }
    public void setCount(int num)
    {
        number = 0;
        number2 = 0;
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("ClickablesLayer");
        //ArrayList arrayPos= new ArrayList();
        for (int i = 0; i< gameObjects.Length; i++)
        {
            if (gameObjects[i].layer == 11)
            {
                number = number + gameObjects[i].GetComponent<FieldOfViewRed>().visibleTargets.Count;
            }

            if (gameObjects[i].layer == 9)
            {
                number2 = number2 + gameObjects[i].GetComponent<FieldOfViewBlue>().visibleTargets.Count;
            }
        } 

        if(number> number2)
        {
            count = number2;
            return;
        } else
        {
            count = number;
        }

    }
}
