using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D physicsCollider;
    public SwitchCharacter switchCharacter;
    public ResourceController resourceController; // Reference to the ResourceController object
    public OxygenController oxygenController;
    GameObject myGameObject;
    

    public float damage = 1;
    public float knockbackForce = 100f;

    private void Start()
    {
        myGameObject = gameObject;
        resourceController = GameObject.Find("ResourceController").GetComponent<ResourceController>();
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

        if (collider.CompareTag("Balloon")) {
            // Player entered the collider, start gathering metal
            oxygenController.AddOxygen(collider.gameObject.GetComponent<BalloonBehaviour>().oxygenGive);
            Destroy(collider.gameObject);
        }
    }


    // trigger handling
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Metal")) {
            // Player entered the collider, start gathering metal
            InvokeRepeating("AddMetal", 0.0f, 1.0f);
        }

        if (other.CompareTag("HealJuice")) {
            // Player entered the collider, start gathering health juice
            InvokeRepeating("AddHealJuice", 0.0f, 1.0f);
        }
    }

    void AddMetal() {
        resourceController.MiningMetal();
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Metal")) {
            // Player exited the collider, stop gathering metal
            CancelInvoke("AddMetal");
        }

        if (other.CompareTag("HealJuice")) {
            // Player exited the collider, stop gathering metal
            CancelInvoke("AddHealJuice");
        }

    }

    void AddHealJuice() {
        resourceController.MiningHealJuice();
    }
}
