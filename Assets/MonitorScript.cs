using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorScript : MonoBehaviour
{
    public Sprite Monitor_1;
    public Sprite Monitor_2;
    public Sprite Monitor_3;
    public Sprite Monitor_4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            if (GetComponent<SpriteRenderer>().sprite == Monitor_1) {
                StartCoroutine(leg());
        } else {
            GetComponent<SpriteRenderer>().sprite = Monitor_1;
        }
        }
        
    }

    IEnumerator leg() {
                yield return new WaitForSeconds(1f); // Change to the desired duration
                GetComponent<SpriteRenderer>().sprite = Monitor_4;
                yield return new WaitForSeconds(1f); // Change to the desired duration
                GetComponent<SpriteRenderer>().sprite = Monitor_3;
                yield return new WaitForSeconds(1f); // Change to the desired duration
                GetComponent<SpriteRenderer>().sprite = Monitor_2;
    }
}
