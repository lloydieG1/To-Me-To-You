using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D physicsCollider;
    public float damage = 1;
    public float knockbackForce = 50f;

    // deal damage to damageable enemies
    void OnCollisionEnter2D(Collision2D collision) {
        Collider2D collider = collision.collider;
        Damageable damageable = collider.GetComponent<Damageable>();
        if(damageable != null) {
            damageable.OnHit(damage);
        }
    }

}