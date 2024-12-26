using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    // Start is called before the first frame update
    public int coinCount;
    public GameObject[] coinObjects;
    public int totalCoins;
    public int totalLength;
    public GameObject UIDoc;
    void Awake()
    {
        coinObjects = GameObject.FindGameObjectsWithTag("Coin");
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void changeCoinCount() {
        coinCount += 1;
    }
    public void coinTotal() {
        coinObjects = GameObject.FindGameObjectsWithTag("Coin");
        totalLength = coinObjects.Length;
        foreach (GameObject coinObject in coinObjects) {
            totalCoins += 1;
        }
    }
    public void wipeCoins() {
        coinObjects = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject coinObject in coinObjects) {
            coinObject.SetActive(true);
        }
        if (totalLength > 1) {
            for (int i=0; i < (coinObjects.Length - 1); i++) {
                Destroy(coinObjects[i]);
            }
        }
    }
    public void subLength() {
        totalLength -= 1;
    }
}
