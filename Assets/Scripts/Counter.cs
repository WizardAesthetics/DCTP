/*
* Class wrote my Eastern Michigan Univerity Computer Science Department
* Team Lead: Krish Narayanan
* Authurs: Blake Johnson, Joesph Stone, Sauel Grone 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{

    public static int count;
    public static int number;
    public static int number2;

    /*
     * gets the numer of house connected
     */
    public int GetCount()
    {
        return count;
    }

    /*
     * Sets the number of house connected
     */
    public void SetCount()
    {
        number = 0;
        number2 = 0;
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("ClickablesLayer");
        for (int i = 0; i< gameObjects.Length; i++)
        {
            if (gameObjects[i].layer == 11)
            {
                number += gameObjects[i].GetComponent<FieldOfViewRed>().visibleTargets.Count;
            }

            if (gameObjects[i].layer == 9)
            {
                number2 += gameObjects[i].GetComponent<FieldOfViewBlue>().visibleTargets.Count;
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
