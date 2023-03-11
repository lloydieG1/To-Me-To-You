using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonBehaviour : MonoBehaviour
{
    public float riseSpeed; // the speed at which the balloon rises
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        // yeet the balloon
        rb.AddForce(new Vector2(0f, riseSpeed), ForceMode2D.Impulse);

    }

    private void FixedUpdate()
    {
        
    }
}

