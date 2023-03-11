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

    // deal damage to damageable enemies
    void OnCollisionEnter2D(Collision2D collision) {
        Collider2D collider = collision.collider;
        Damageable damageable = collider.GetComponent<Damageable>();
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
