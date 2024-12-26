using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;
public class UIScript : MonoBehaviour
{   
    public SliderInt dimensionSlider;
    public SliderInt speedSlider;
    public VisualElement root;
    public SliderInt collectibleSlider;
    public DropdownField skinDropdown;
    public DropdownField styleDropdown;
    public int dimensionInt;
    public Vector3 scaleBy;
    public GameObject dimensionValue;
    public int scaleChange;
    public Vector3 scaleWall;
    public Vector3 wallPosition;
    public GameObject scaleValue;
    public int index;
    public GameObject UIDoc;
    public GameObject coin;
    public GameObject goal;
    public int coinCount;
    public int speed;
    public int totalLength;
    // public Material[] Materials = {};
    //Change chances of walls being turned a certain degree around.
    public int[] degreeRotation = {0, 0, 45, 90, 90};
    //Later will contain all objects with the "RandomWall" tag on it.
    public GameObject[] randomWalls;
    public GameObject[] coinObjects;
    public GameObject[] coinSelection;
    public int totalCoins;
    /*
    public List<Material> materials = new List<Material>();
    public List<string> materialList = new List<string>();
    */
    void Awake()
    {
        UIDoc = GameObject.Find("UIDocument");
        coin = GameObject.FindWithTag("Coin");
        goal = GameObject.FindWithTag("Goal");
        coinSelection = GameObject.FindGameObjectsWithTag("Coin");
    }
    //Most of Code in OnEnable() by MadCat Tutorials on Youtube
    void OnEnable() {
        // Gets UI Document
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Button startButton = root.Q<Button>("ButtonOne");
        dimensionSlider = root.Q<SliderInt>("DimensionSlider");
        collectibleSlider = root.Q<SliderInt>("CollectibleSlider");
        skinDropdown = root.Q<DropdownField>("SkinDropdown");
        styleDropdown = root.Q<DropdownField>("StyleDropdown");
        // enemyToggle = root.Q<Toggle>("EnemyToggle");
		startButton.clicked += () => onTerminate();
    }
    void onTerminate() {
        scaleChange = dimensionSlider.value;
        scaleBy = new Vector3(scaleChange, scaleChange, scaleChange);
        GameObject.FindWithTag("Wall").transform.localScale = new Vector3(scaleChange, scaleChange, scaleChange * 10);
        GameObject.FindWithTag("Wall").transform.position = new Vector3((scaleChange * 5), 0 + (scaleChange / 2), 0);
        GameObject.FindWithTag("Plane").transform.localScale = scaleBy;
        GameObject.FindWithTag("Player").transform.position = new Vector3(scaleChange /  2, 0.75f, scaleChange / 2);
        GameObject.FindWithTag("Player").transform.localScale = scaleBy / 4;
        GameObject.FindWithTag("WallRight").transform.localScale = new Vector3(scaleChange, scaleChange, scaleChange * 10);
        GameObject.FindWithTag("WallRight").transform.position = new Vector3(-(scaleChange * 5), 0 + (scaleChange / 2), 0);
        GameObject.FindWithTag("WallUp").transform.localScale = new Vector3(scaleChange, scaleChange, scaleChange * 10);
        GameObject.FindWithTag("WallUp").transform.position = new Vector3(0, 0 + (scaleChange / 2), (scaleChange * 5));
        GameObject.FindWithTag("WallDown").transform.localScale = new Vector3(scaleChange, scaleChange, scaleChange * 10);
        GameObject.FindWithTag("WallDown").transform.position = new Vector3(0, 0 + (scaleChange / 2), -(scaleChange * 5));
        randomWalls = GameObject.FindGameObjectsWithTag("RandomWall");
        foreach (GameObject changedWall in randomWalls) {
            changePos(changedWall);
        }
        for (int i=0; i < (collectibleSlider.value - 1); i++) {
            GameObject.Instantiate(coin).transform.position = new Vector3(UnityEngine.Random.Range(scaleChange * 3.5f, -scaleChange * 3.5f), 0, UnityEngine.Random.Range(scaleChange * 3.5f, -scaleChange * 3.5f));
        }
        GameObject.FindWithTag("Goal").transform.position = new Vector3(UnityEngine.Random.Range(scaleChange * 3.5f, -scaleChange * 3.5f), 0, UnityEngine.Random.Range(scaleChange * 3.5f, -scaleChange * 3.5f));
        GameObject.FindWithTag("Score").GetComponent<ScoreTracker>().coinTotal();
        stopScene();
    }
    void Update() {
        GameObject.FindWithTag("Player").transform.rotation = Quaternion.Euler(0, 0, 0);
        GameObject.FindWithTag("MainCamera").transform.position = new Vector3(0.0f, 100.0f, 0.0f);
        if (Input.GetKeyDown(KeyCode.R)) {
            GameObject.FindWithTag("Score").GetComponent<ScoreTracker>().wipeCoins();
            restartScene();
        }
    }
    void changePos(GameObject objectToChange)
    {
        int[] scaleTo = { -scaleChange * 3, -scaleChange * 4, -scaleChange * 5, scaleChange * 3, scaleChange * 4, scaleChange * 5 };
        float[] mutableDistance = {0.0f};
        string[] loopString = {"Yes"};
        foreach(GameObject wallAgain in randomWalls) {
            foreach (GameObject changedWall in randomWalls) {
                float distance = Vector3.Distance(wallAgain.transform.position, changedWall.transform.position);
                mutableDistance[0] = distance;
                //floats are immutable, meaning they cannot be changed.
                if (mutableDistance[0] < (scaleChange * 3)) {
                        float randomX = UnityEngine.Random.Range(scaleChange * 3.5f, -scaleChange * 3.5f);
                        float randomZ = UnityEngine.Random.Range(scaleChange * 3.5f, -scaleChange * 3.5f);
                        var randomIndex = UnityEngine.Random.Range(0, degreeRotation.Length);
                        var randomIndex2 = UnityEngine.Random.Range(0, scaleTo.Length);
                        var randomDegree = degreeRotation[randomIndex];
                        int randomScaleZ = scaleTo[randomIndex2];
                        objectToChange.transform.position = new Vector3(randomX, 0, randomZ);
                        objectToChange.transform.localScale = new Vector3(1, scaleChange, randomScaleZ);
                        objectToChange.transform.rotation = Quaternion.Euler(0, randomDegree, 0);
                        float newDistance = Vector3.Distance(wallAgain.transform.position, changedWall.transform.position);  
                        mutableDistance[0] = newDistance;
                }
            }
        }
    }
    void stopScene() {
        UIDoc.SetActive(false);
    }
    void restartScene() {
        totalCoins = 0;
        UIDoc.SetActive(true);   
        goal.SetActive(true);   
        coinCount = 0;
        foreach (GameObject coinSelect in coinSelection) {
            coinSelect.SetActive(true);
        }
    }
    void OnCollisionEnter(Collision collision) {
        coinCount = GameObject.FindWithTag("Score").GetComponent<ScoreTracker>().coinCount;
        coinObjects = GameObject.FindWithTag("Score").GetComponent<ScoreTracker>().coinObjects;
        totalCoins = GameObject.FindWithTag("Score").GetComponent<ScoreTracker>().totalCoins;
        totalLength = GameObject.FindWithTag("Score").GetComponent<ScoreTracker>().totalLength;
        if (gameObject.tag == "Goal") {
            totalCoins = GameObject.FindWithTag("Score").GetComponent<ScoreTracker>().totalCoins;
            if (coinCount >= totalCoins) {
                    gameObject.SetActive(false);
                    Debug.Log("You Win!");
            } else {
                    Debug.Log("You must get all coins first before you can complete the maze!");
            }
        } else if (gameObject.tag == "Coin") {
            GameObject.FindWithTag("Score").GetComponent<ScoreTracker>().changeCoinCount();
            if (totalLength > 1) {
                Destroy(gameObject);
            } else {
                gameObject.SetActive(false);
            }
            GameObject.FindWithTag("Score").GetComponent<ScoreTracker>().subLength();
        }
    }
}
