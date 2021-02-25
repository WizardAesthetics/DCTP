
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
    public GameObject xStreet;
    public GameObject yStreet;
    public GameObject crossWalk;
    float seed;
    int[,] mappgrid;
    private static ArrayList lacationArray;
    private static ArrayList buildingsArray;


    // Start is called before the first frame update
    void Start()
    {
        lacationArray = new ArrayList();
        buildingsArray = new ArrayList();
        mappgrid = new int[mapWidth, mapHeight];

        for (int i =0; i< mapHeight; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                mappgrid[j,i] = (int)(Mathf.PerlinNoise(j / 5.0f + seed, i / 5.0f + seed) * 10);
            }
        }

        int x = 0;
        for (int i = 0; i < 50; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                mappgrid[x, j] = -1;
            }
            x += Random.Range(3, 3);
            if (x >= mapWidth) break;
        }

        int z = 0;
        for (int i = 0; i < 50; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                if(mappgrid[j, z] == -1)
                    mappgrid[j, z] = -3;
                else
                    mappgrid[j, z] = -2;
            }
            z += Random.Range(3, 3);
            if (z >= mapHeight) break;
        }

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

                int result = mappgrid[j, i]; //finding a number based on the PerlinNoise
                Vector3 pos = new Vector3(j*buildingFootPrint, 1, i*buildingFootPrint); //finding out where then building will be placed

                //based on result figuring out what to place
                if (result == -3)
                    Instantiate(crossWalk, pos, crossWalk.transform.rotation);
                else if (result == -2)
                    Instantiate(xStreet, pos, xStreet.transform.rotation);
                else if (result == -1)
                    Instantiate(yStreet, pos, yStreet.transform.rotation);
                else if (result < 2) 
                {
                    Instantiate(buildings[5], pos, Quaternion.identity);
                }
                else if (result < 3)
                {
                    Instantiate(buildings[1], pos, Quaternion.identity);
                    lacationArray.Add(pos);
                    buildingsArray.Add(buildings[1]);
                }
                else if (result < 4)
                {
                    Instantiate(buildings[2], pos, Quaternion.identity);
                    lacationArray.Add(pos);
                    buildingsArray.Add(buildings[2]);
                }
                else if (result < 5)
                {
                    Instantiate(buildings[3], pos, Quaternion.identity);
                    lacationArray.Add(pos);
                    buildingsArray.Add(buildings[3]);
                }
                else if (result < 6)
                {
                    Instantiate(buildings[4], pos, Quaternion.identity);
                    lacationArray.Add(pos);
                    buildingsArray.Add(buildings[4]);
                }
                else if (result < 7)
                {
                    Instantiate(buildings[0], pos, Quaternion.identity);
                    lacationArray.Add(pos);
                    buildingsArray.Add(buildings[0]);
                }
                else if (result < 10)
                {
                    Instantiate(buildings[6], pos, Quaternion.identity);
                }
            }
        }
    }

   public ArrayList getPosArray()
   {
        return lacationArray;
   }

    public ArrayList getBuildingsArray()
    {
        return buildingsArray;
    }
}
