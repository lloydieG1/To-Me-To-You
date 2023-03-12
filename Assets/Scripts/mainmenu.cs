using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenu : MonoBehaviour
{
    public Sprite Keyboard_1;
    public Sprite Keyboard_2;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            if (GetComponent<SpriteRenderer>().sprite == Keyboard_1) {
                StartCoroutine(leg());
        } else {
            GetComponent<SpriteRenderer>().sprite = Keyboard_1;
        }
        }
        
    }

    IEnumerator leg() {
        GetComponent<SpriteRenderer>().sprite = Keyboard_2;
                yield return new WaitForSeconds(0.1f); // Change to the desired duration
                GetComponent<SpriteRenderer>().sprite = Keyboard_1;
    }


}
