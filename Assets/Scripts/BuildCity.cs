
/*
 * Author: Blake Johnson
 * Created: 12/3/2020
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCity : MonoBehaviour
{

    public GameObject[] buildings; //Array of building 
    public int mapWidth = 20; //Width the building will be places on
    public int mapHeight = 20;//depth the building will be places on
    public float buildingFootPrint = 5; //distance between building
    public int index;
    float seed;

    // Start is called before the first frame update
    void Start()
    {

        if (index > 30)
        {
           seed = Random.Range(0, 100); //making a seed for random PerlinNoise offset
        }
        else
        {
            seed = index; //making a seed for random PerlinNoise offset
        }
        for (int i = 0; i < mapHeight; i++)
        {
            for(int j = 0; j< mapWidth; j++)
            {

                int result = (int)(Mathf.PerlinNoise(j/5.0f + seed, i/5.0f + seed) * 10); //finding a number based on the PerlinNoise
                Vector3 pos = new Vector3(j*buildingFootPrint, 0, i*buildingFootPrint); //finding out where then building will be placed

                //based on result figuring out what to place
                if(result<2)
                    Instantiate(buildings[5], pos, Quaternion.identity);
                else if (result < 3)
                    Instantiate(buildings[1], pos, Quaternion.identity);
                else if (result < 4)
                    Instantiate(buildings[2], pos, Quaternion.identity);
                else if (result < 5)
                    Instantiate(buildings[3], pos, Quaternion.identity);
                else if (result < 6)
                    Instantiate(buildings[4], pos, Quaternion.identity);
                else if (result < 7)
                    Instantiate(buildings[0], pos, Quaternion.identity);
                else if (result < 10)
                    Instantiate(buildings[6], pos, Quaternion.identity);
            }
        }

    }
}
