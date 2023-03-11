using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{

    //Movement
    public float speed;
    public float jump;
    private float moveVelocity;
    private bool isGrounded = true; 

    private Rigidbody2D rb;   

    private void Start() {
        // Get the player's rigidbody component
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update () 
    {
        //Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2 (rb.velocity.x, jump);
            isGrounded = false;
        }
        

        moveVelocity = 0;

        //Left Right Movement
        if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) 
        {
            moveVelocity = -speed;
        }
        if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) 
        {
            moveVelocity = speed;
        }

        rb.velocity = new Vector2 (moveVelocity, rb.velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player has collided with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

