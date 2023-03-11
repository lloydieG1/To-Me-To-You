using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCharacter : MonoBehaviour, Damageable {

    Rigidbody2D rb;
    Collider2D physicsCollider;
    [SerializeField] float _health = 3f;

    public float Health {
        set{
            if(value < _health){
                // Stuff that happens when damage is taken
            }

            _health = value;
        }

        get{
            return _health;
        }

    }

    public void OnHit(float damage, Vector2 knockback){
        Health -= damage;

        rb.AddForce(knockback, ForceMode2D.Impulse);
    }
}