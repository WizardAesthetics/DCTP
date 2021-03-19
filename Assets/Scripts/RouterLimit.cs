using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RouterLimit : MonoBehaviour
{
    public TextMeshProUGUI countText;

    public int count = 2;

    public GameObject button;

    

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
            button.SetActive(false);
        }
    }

    public void Reduce()
    {
        count = count - 1;
        SetCountText();
    }
}
