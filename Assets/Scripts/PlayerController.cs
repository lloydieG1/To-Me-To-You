using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D physicsCollider;
    public SwitchCharacter switchCharacter;
    GameObject myGameObject;

    public float damage = 1;
    public float knockbackForce = 100f;

    private void Start()
    {
        myGameObject = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // switch character command
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            switchCharacter.SwitchPlayer(myGameObject);
            switchCharacter.currentPlayer.GetComponent<PlayerController>().enabled = true;
            switchCharacter.currentPlayer.GetComponent<PlayerMovement>().enabled = true;
        }
    }

    
}
