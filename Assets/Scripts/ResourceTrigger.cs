using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTrigger : MonoBehaviour
{
    public string tagToSet;
    public int resourceAmount;
    public int depletionRate;


    private void Start() 
    {   
        // if the tag is not set
        if (gameObject.CompareTag("Untagged") && !string.IsNullOrEmpty(tagToSet))
        {
            gameObject.tag = tagToSet;
        } else {
            tagToSet = gameObject.tag;
        }
    }

    public void mine() 
    {
        resourceAmount -= depletionRate;
    }


    private void OnDrawGizmos()
    {
        #if UNITY_EDITOR
        // Draw a wireframe rectangle around the trigger collider
        if (gameObject.CompareTag("Metal")){
            Gizmos.color = Color.black;
        } else if (gameObject.CompareTag("HealJuice")) {
            Gizmos.color = Color.red;
        }
        
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider2D>().size);
        #endif
    }

}
