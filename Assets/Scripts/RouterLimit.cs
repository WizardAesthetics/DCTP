/*
* Class wrote my Eastern Michigan Univerity Computer Science Department
* Team Lead: Krish Narayanan
* Authurs: Blake Johnson, Joesph Stone, Sauel Grone 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RouterLimit : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public static int count2 = 4;
    public GameObject button;
    public GameObject image;

    public void SetCountText()
    {
       countText.text = "Sector Acess Point Limit: " + count2;
    }


    // Update is called once per frame
    public void Update()
    {
        if (count2 < 1)
        {
            button.SetActive(false);
            image.SetActive(true);
        }
        if (count2 >= 1)
        {
          button.SetActive(true);
          image.SetActive(false);
        }
        countText.text = "Sector Acess Point Limit: " + count2;

    }

    /*
     * Reduced the number of routers able to be used
     */
    public void Reduce()
    {
        count2--;
    }

    /*
     * Gets the cnumber of routers available
     */
    public int GetCount()
    {
        return count2;
    }

    /*
     * Sets the number of Anntennas
     */
    public void SetCount(int x)
    {
        count2 += x;
    }

}
