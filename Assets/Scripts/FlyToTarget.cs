using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyToTarget : MonoBehaviour
{
    [SerializeField] float flySpeed = 5f;
    Rigidbody2D rb;
    [SerializeField] Transform target;
    Vector2 scaleChange, moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
        }
    }

    private void FixedUpdate() {
        if(target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * flySpeed;      
        }
        if(target.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }
        if(target.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1);
        }
    }
}
