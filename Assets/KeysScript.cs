using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysScript : MonoBehaviour
{
    public Sprite Key_1;
    public Sprite Key_2;
    public string arrowtype;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (arrowtype == "Up"){
            if (Input.GetKeyDown(KeyCode.UpArrow)){
                if (GetComponent<SpriteRenderer>().sprite == Key_1) {
                    StartCoroutine(leg());
                } else {
                    GetComponent<SpriteRenderer>().sprite = Key_1;
                }
            }
        }
        if (arrowtype == "Left"){
            if (Input.GetKeyDown(KeyCode.LeftArrow)){
                if (GetComponent<SpriteRenderer>().sprite == Key_1) {
                    StartCoroutine(leg());
                } else {
                    GetComponent<SpriteRenderer>().sprite = Key_1;
                }
            }
        }
        if (arrowtype == "Right"){
            if (Input.GetKeyDown(KeyCode.RightArrow)){
                if (GetComponent<SpriteRenderer>().sprite == Key_1) {
                    StartCoroutine(leg());
                } else {
                    GetComponent<SpriteRenderer>().sprite = Key_1;
                }
            }
        }
        if (arrowtype == "Down"){
            if (Input.GetKeyDown(KeyCode.DownArrow)){
                if (GetComponent<SpriteRenderer>().sprite == Key_1) {
                    StartCoroutine(leg());
                } else {
                    GetComponent<SpriteRenderer>().sprite = Key_1;
                }
            }
        }
        
    }

    IEnumerator leg() {
        GetComponent<SpriteRenderer>().sprite = Key_2;
                yield return new WaitForSeconds(0.1f); // Change to the desired duration
                GetComponent<SpriteRenderer>().sprite = Key_1;
    }


}

