using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D physicsCollider;
    public float damage = 1;
    public float knockbackForce = 10f;

    // deal damage to damageable enemies
    void OnCollisionEnter2D(Collision2D collision) {
        Collider2D collider = collision.collider;
        Damageable damageable = collider.GetComponent<Damageable>();
        Debug.Log("yex");
        if(damageable != null) {
            Debug.Log("Touch");
            // Offset for collision detection changes the direction where the force is coming from
            Vector2 direction = (collider.transform.position - transform.position).normalized;

            // Knockback is in direction of swordCollider towards collider
            Vector2 knockback = direction * knockbackForce;

            // run the OnHit implementation and pass our Vector2 force
            damageable.OnHit(damage, knockback);
        }
    }
}