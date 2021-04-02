using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{

    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject MovementControl;
    public GameObject buttonlock;
    public GameObject buttonlock1;
    public GameObject buttonlock2;
    public GameObject Image;
    public GameObject Image1;
    private BuildCity city = new BuildCity();
    private int count;
    private FieldOfViewBlue fieldOfView = new FieldOfViewBlue();


    //public Collider2D RedCollider;
    // public Collider2D BlueCollider;

    // Start is called before the first frame update
    void Start()
    {
        countText.text = "Houses Connected: " + 0+"\\18";
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("ClickablesLayer");
        countText.text = "Houses Connected: " + getCountNUm() + "\\18"; 
        if(getCountNUm() > (city.getBuildingsArray().Count * 0.5))
        {
            winTextObject.SetActive(true);
            Image.SetActive(true);
            Image1.SetActive(true);
            MovementControl.GetComponent<ThirdPMovement>().enabled = false; 
            buttonlock.SetActive(false);
            buttonlock1.SetActive(false);
            buttonlock2.SetActive(false);

        }
    }
  
    public int getCountNUm()
    {
        count = FieldOfViewBlue.counter.getCount();
        return count;
    }

}