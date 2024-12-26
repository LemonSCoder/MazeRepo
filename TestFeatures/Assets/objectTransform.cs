using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;

public class objectTransform : MonoBehaviour
{
    // Start is called before the first frame update
    public SliderInt dimensionSlider;
    public GameObject UIDoc;
    public int scaleChange;
    void Awake()
    {
        UIDoc = GameObject.Find("UIDocument");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            GameObject.Instantiate(UIDoc);
            // VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            // dimensionSlider = root.Q<SliderInt>("DimensionSlider");
            // scaleChange = dimensionSlider.value;
        }
    }
}
