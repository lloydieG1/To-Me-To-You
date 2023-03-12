using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    //Movement
    public bool lockMovement;
    public float LockTimeLength = 0.3f;
    private float moveVelocity;
    private bool isGrounded;
    SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;   

    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private float jumpForce = 1f;

    [SerializeField]
    private LayerMask collisionMask;

    [Header("Knockback")]
    [SerializeField] private Transform _center;
    [SerializeField] private float _knockbackVel = 10f;
    [SerializeField] private bool _knockbacked;
    [SerializeField] private float knockbackTime = 2f;

    private void Start() {
        // Get the player's rigidbody component
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        // spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update () 
    {
        var inputX = Input.GetAxisRaw("Horizontal");


        var newXVel = _knockbacked ? Mathf.Lerp(rb.velocity.x, 0f, Time.deltaTime * 3) : inputX * speed;
        rb.velocity = new Vector2(newXVel, rb.velocity.y);
        

        //Jumping
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        if(inputX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(inputX), 1, 1);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player has collided with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput > 0) // moving right
        {
            // face right
            rb.transform.localScale = new Vector2(1f, 0.99f); // face right
        }
        else if (horizontalInput < 0) // moving left
        {
            // face left
            rb.transform.localScale = new Vector2(-1f, 0.99f); // face left
        }
    }

    private void LockMovement(){
        lockMovement = true;
        StartCoroutine(MakeUnmovable());
    }

    private IEnumerator MakeUnmovable()
    {
        // Wait for 0.3 seconds
        yield return new WaitForSeconds(LockTimeLength);

        // Set isUnmovable back to false
        lockMovement = false;
    }

    public void Knockback(Transform t){
        var dir = transform.position - t.position;
        _knockbacked = true;
        rb.velocity = (dir.normalized * _knockbackVel);
        StartCoroutine(Unknockback());
    }

    private IEnumerator Unknockback()
    {
        yield return new WaitForSeconds(knockbackTime);
        _knockbacked = false;
    }
}

