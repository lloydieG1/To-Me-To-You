using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToTarget : MonoBehaviour
{
    [SerializeField] float walkSpeed = 5f;
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
            moveDirection = direction;
        }
    }

    private void FixedUpdate() {
        if(target)
        {
            transform.position = Vector2.MoveTowards (transform.position, new Vector2(target.position.x, transform.position.y), walkSpeed * Time.deltaTime);
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
