using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;

public class playerControls : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
        
        if (Input.GetKey(KeyCode.LeftArrow)) {
            gameObject.transform.position += new Vector3(-(1.0f * Time.deltaTime * speed), 0.0f, 0.0f);
            // speed *= 1.001f;
        } 
        if (Input.GetKey(KeyCode.RightArrow)) {
            gameObject.transform.position += new Vector3(1.0f * Time.deltaTime * speed, 0.0f, 0.0f);
            // speed *= 1.001f;
        } 
        if (Input.GetKey(KeyCode.UpArrow)) {
            gameObject.transform.position += new Vector3(0.0f, 0.0f, 1.0f * Time.deltaTime * speed);
            // speed *= 1.001f;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            gameObject.transform.position += new Vector3(0.0f, 0.0f, -(1.0f * Time.deltaTime * speed));
            // speed *= 1.001f;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            speed = 10.0f;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            speed = 10.0f;
        } 
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            speed = 10.0f;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            speed = 10.0f;
        }
    }
}
