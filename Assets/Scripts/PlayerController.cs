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
    

    // public float damage = 1;
    // public float knockbackForce = 100f;

    private ResourceTrigger currentResource;
    private AudioManager audioManager;
    

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
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
            // run the OnHit implementation and pass our Vector2 force
        // damageable.OnHit(damage, knockback);

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Balloon") && gameObject.name == "MoonPlayer") {
            oxygenController.AddOxygen(collision.gameObject.GetComponent<BalloonBehaviour>().oxygenGive);
            Destroy(collision.gameObject);
        }
    }


    // trigger handling
    void OnTriggerEnter2D(Collider2D other) {     
        if (other.CompareTag("Metal")) {
            // Player entered the collider, start gathering metal
            currentResource = other.GetComponent<ResourceTrigger>();
            InvokeRepeating("AddMetal", 0.0f, 1.0f);
            
        }

        if (other.CompareTag("HealJuice")) {
            currentResource = other.GetComponent<ResourceTrigger>();
            // Player entered the collider, start gathering health juice
            InvokeRepeating("AddHealJuice", 0.0f, 1.0f);
        }
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

    void AddMetal() {
        if(currentResource.resourceAmount > 0)
        {
            audioManager.Play("Mine");
            currentResource.mine();
            resourceController.AddMetal(currentResource.depletionRate);
        } else {
            Destroy(currentResource.gameObject);
        } 
    }

    void AddHealJuice() {
        if(currentResource.resourceAmount >= 0)
        {
            currentResource.mine();
            resourceController.AddHealJuice(currentResource.depletionRate);
        } else {
            Destroy(currentResource.gameObject);
        } 
    }
}
