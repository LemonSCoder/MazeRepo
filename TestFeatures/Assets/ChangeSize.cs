using UnityEngine;
public class ChangeSize : MonoBehaviour
{
    public Vector3 scaleBy;
    public GameObject dimensionValue;
    public int scaleChange;
    void newFunction()
    {
    }
    void Update()
    {
        if (GameObject.FindWithTag("Plane")) {
            gameObject.transform.localScale = scaleBy;
        }
    }
}