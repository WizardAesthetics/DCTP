using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RouterLimit : MonoBehaviour
{
    public TextMeshProUGUI countText;

    public static int count = 4;

    public GameObject button;

    public GameObject image;

    // Start is called before the first frame update
    public void Start()
    {
       SetCountText();
    }
  
    public void SetCountText()
    {
      countText.text = count.ToString();
    }


    // Update is called once per frame
    public void Update()
    {
        if (count < 1)
        {
           // Debug.Log("Inside Update If");
            button.SetActive(false);
            image.SetActive(true);
        }
        if (count >= 1)
        {
          button.SetActive(true);
          image.SetActive(false);
        }
    }

    public void Reduce()
    {
        count = count - 1;

    }

    public int getCount()
    {
        return count;
    }

    public void setCount(int x)
    {
        count = count + x;
    }

}
