using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SwitchCharacter switchCharacter;
    public ResourceController resourceController; // Reference to the ResourceController object
    GameObject myGameObject;

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

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("ree");
        if (other.CompareTag("Metal")) {
            // Player entered the collider, start gathering metal
            InvokeRepeating("AddMetal", 0.0f, 1.0f);
        }

        if (other.CompareTag("HealJuice")) {
            // Player entered the collider, start gathering metal
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
