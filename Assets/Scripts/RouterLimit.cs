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

    // Start is called before the first frame update
    public void Start()
    {
       SetCountText();
    }
  
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

    public void Reduce()
    {
        count2 = count2 - 1;
        SetCountText();
    }

    public int getCount()
    {
        return count2;
    }

    public void setCount(int x)
    {
        count2 = count2 + x;
    }

}
