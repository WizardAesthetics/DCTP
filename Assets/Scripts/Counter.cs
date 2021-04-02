using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{

    public static int count;
    private GameObject otherChild;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public int getCount()
    {
        return count;
    }
    public void setCount(int num)
    {
        if (num>0)
        {
            count = count + 1;
        }
    }
}
