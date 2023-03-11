using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenPump : MonoBehaviour
{
    public float deflateRate; // how fast the balloon deflates (in units per second)
    public float inflateRate;
    public float releaseOxygen; // how much oxygen is released when the balloon is filled (in arbitrary units)
    public KeyCode inflateKey = KeyCode.LeftShift; // the key used to inflate the balloon
    public Collider2D triggerCollider; // the collider that triggers the oxygen pump
    public GameObject balloonPrefab;

    private bool isFilling = false; // whether the player is currently filling the balloon
    private float currentOxygen; // the current amount of oxygen in the balloon


    private void Start()
    {
        // Get the Collider2D component attached to this GameObject
        triggerCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isFilling = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isFilling = false;
        }
    }

    private void Update()
    {
        if (isFilling && Input.GetKeyDown(inflateKey))
        {
            // inflate the balloon
            currentOxygen += inflateRate;
            Debug.Log("oxygen: " + currentOxygen);
            
        }
        else
        {
            // deflate the balloon
            currentOxygen -= deflateRate * Time.deltaTime;
        }

        // clamp the currentOxygen value between 0 and releaseOxygen
        currentOxygen = Mathf.Clamp(currentOxygen, 0.0f, releaseOxygen);

        if (currentOxygen >= releaseOxygen)
        {
            // release the balloon and its oxygen
            Debug.Log("Balloon released with " + currentOxygen + " units of oxygen.");
            currentOxygen = 0.0f;

            // instantiate balloon prefab
            Instantiate(balloonPrefab, transform.position, Quaternion.identity);
        }
    }
}

