using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // The speed of the player movement
    private float horizontalInput; // The horizontal input from the player
    private float verticalInput; // The vertical input from the player




    // Update is called once per frame
    void Update()
    {
        // Get the player's input from the keyboard or joystick
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Move the player's position based on their input and the speed
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + movement.x, transform.position.y + movement.y);
    }
}