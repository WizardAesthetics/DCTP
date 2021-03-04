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
    private int count;
    private BuildCity city = new BuildCity();

    // Start is called before the first frame update
    void Start()
    {
        countText.text = "Houses Connected: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("ClickablesLayer");
        countText.text = "Houses Connected: " + getcount(gameObjects);
    }

    private int getcount(GameObject[] gameObjects)
    {
        count = 0;
        for (int i = 0; i< gameObjects.Length; i++)
        {
            if (gameObjects[i].layer == 12)
            {
                count++;
            }
            if (count >= (city.getBuildingsArray().Count * 0.6))
            {
                winTextObject.SetActive(true);
                MovementControl.GetComponent<ThirdPMovement>().enabled = false;
                buttonlock.SetActive(false);
            }
        }
        return count;
    }

}
