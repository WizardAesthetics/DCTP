/*
* Class wrote my Eastern Michigan Univerity Computer Science Department
* Team Lead: Krish Narayanan
* Authurs: Blake Johnson, Joesph Stone, Sauel Grone 
*/

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private Counter counter = new Counter();

    private void Awake()
    {
        PlaceObject.objectArray.Clear();
        RouterLimit.count2 = 4;
        Counter.number = 0;
        Counter.number2 = 0;
        counter.SetCount();

    }
    /*
     * Checking if the house connected have surpased the win condition
     */
    void Update()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("ClickablesLayer");
        countText.text = "Houses Connected: " + GetCountNUm() + "\\" + (int)(city.GetBuildingsArray().Count * 0.5); 

        /*
         * Loads win scene
         */
        if (GetCountNUm() >= (int)(city.GetBuildingsArray().Count * 0.5))
        {
            if (SceneManager.GetActiveScene().buildIndex + 1 > 4)
            {
                SceneManager.LoadScene("Win");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
  
    /*
     * get the number of house connected
     */
    public int GetCountNUm()
    {
        count = FieldOfViewRed.counter.GetCount();
        return count;
    }

}