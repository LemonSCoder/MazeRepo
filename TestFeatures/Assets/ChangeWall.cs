/* using UnityEngine;
using System.Linq;
using System.Collections.Generic;
public class List<T> { };
public class ChangeWall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Vector3 scaleWall;
    public Vector3 wallPosition;
    public GameObject scaleValue;
    public int scaleBy;
    public int index;
    public bool stopLoop = false;
    public string stopLoopString;
    //Change chances of walls being turned a certain degree around.
    public int[] degreeRotation = { 0, 0, 45, 90, 90 };
    //Later will contain all objects with the "RandomWall" tag on it.
    public GameObject[] randomWalls;
    //Just for future reference: Awake() functions are called BEFORE Start() functions.
    void Start()
    {
        scaleValue = GameObject.FindWithTag("Plane");
        scaleBy = scaleValue.GetComponent<UIScript>().scaleChange;
        scaleWall = new Vector3(scaleBy, scaleBy, scaleBy * 10);
        randomWalls = GameObject.FindGameObjectsWithTag("RandomWall");
        foreach (GameObject changedWall in randomWalls) {
            changePos(changedWall);
        }
    }
    // Update is called once per frame
    void Update() {
        if (GameObject.FindWithTag("Wall"))
        {
            GameObject.FindWithTag("Wall").transform.localScale = scaleWall;
            GameObject.FindWithTag("Wall").transform.position = new Vector3((scaleBy * 5), 0 + (scaleBy / 2), 0);
        }
        if (GameObject.FindWithTag("WallRight"))
        {
            GameObject.FindWithTag("WallRight").transform.localScale = scaleWall;
            GameObject.FindWithTag("WallRight").transform.position = new Vector3(-(scaleBy * 5), 0 + (scaleBy / 2), 0);
        }
        if (GameObject.FindWithTag("WallUp"))
        {
            GameObject.FindWithTag("WallUp").transform.localScale = scaleWall;
            GameObject.FindWithTag("WallUp").transform.position = new Vector3(0, 0 + (scaleBy / 2), (scaleBy * 5));
        }
        if (GameObject.FindWithTag("WallDown"))
        {
            GameObject.FindWithTag("WallDown").transform.localScale = scaleWall;
            GameObject.FindWithTag("WallDown").transform.position = new Vector3(0, 0 + (scaleBy / 2), -(scaleBy * 5));
        }
    }

    void changePos(GameObject objectToChange)
    {
        int[] scaleTo = { -scaleBy * 3, -scaleBy * 4, -scaleBy * 5, scaleBy * 3, scaleBy * 4, scaleBy * 5 };
        float[] mutableDistance = {0.0f};
        string[] loopString = {"Yes"};
        foreach(GameObject wallAgain in randomWalls) {
            foreach (GameObject changedWall in randomWalls) {
                float distance = Vector3.Distance(wallAgain.transform.position, changedWall.transform.position);
                mutableDistance[0] = distance;
                //floats are immutable, meaning they cannot be changed.
                if (mutableDistance[0] < (scaleBy * 3)) {
                        float randomX = UnityEngine.Random.Range(scaleBy * 3.5f, -scaleBy * 3.5f);
                        float randomZ = UnityEngine.Random.Range(scaleBy * 3.5f, -scaleBy * 3.5f);
                        var randomIndex = UnityEngine.Random.Range(0, degreeRotation.Length);
                        var randomIndex2 = UnityEngine.Random.Range(0, scaleTo.Length);
                        var randomDegree = degreeRotation[randomIndex];
                        int randomScaleZ = scaleTo[randomIndex2];
                        objectToChange.transform.position = new Vector3(randomX, 0, randomZ);
                        objectToChange.transform.localScale = new Vector3(1, scaleBy, randomScaleZ);
                        objectToChange.transform.rotation = Quaternion.Euler(0, randomDegree, 0);
                        float newDistance = Vector3.Distance(wallAgain.transform.position, changedWall.transform.position);  
                        mutableDistance[0] = newDistance;
                }
            }
        }
    }
}
*/