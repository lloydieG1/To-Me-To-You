using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenPump : MonoBehaviour
{
    public float deflateRate; // how fast the balloon deflates (in units per second)
    public float inflateRate;
    public float releaseOxygen; // how much oxygen is released when the balloon is filled (in arbitrary units)
    private KeyCode inflateKey = KeyCode.Space; // the key used to inflate the balloon
    public Collider2D triggerCollider; // the collider that triggers the oxygen pump
    public GameObject balloonPrefab;
    public Sprite[] balloons;

    private bool isFilling = false; // whether the player is currently filling the balloon
    private float currentOxygen; // the current amount of oxygen in the balloon
    private int roundedPercentageFull;


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
        if (isFilling && Input.GetKeyDown(inflateKey) && currentOxygen >= releaseOxygen)
        {
            // release the balloon and its oxygen
            Debug.Log("Balloon released with " + currentOxygen + " units of oxygen.");
            currentOxygen = 0.0f;

            // instantiate balloon prefab
            Instantiate(balloonPrefab, transform.position, Quaternion.identity);
            
            Debug.Log("oxygen: " + currentOxygen);
            
        }

        if (currentOxygen < releaseOxygen)
        {
            // deflate the balloon
            currentOxygen += inflateRate * Time.deltaTime;
        }

        // clamp the currentOxygen value between 0 and releaseOxygen
        roundedPercentageFull = Mathf.RoundToInt(currentOxygen/releaseOxygen * 100); 

        switch (roundedPercentageFull)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = balloons[7];
                break;
            case 5:
                GetComponent<SpriteRenderer>().sprite = balloons[6];
                break;
            case 10:
                GetComponent<SpriteRenderer>().sprite = balloons[5];
                break;
            case 20:
                GetComponent<SpriteRenderer>().sprite = balloons[4];
                break;
            case 30:
                GetComponent<SpriteRenderer>().sprite = balloons[3];
                break;
            case 50:
                GetComponent<SpriteRenderer>().sprite = balloons[2];
                break;
            case 75:
                GetComponent<SpriteRenderer>().sprite = balloons[1];
                break;
            case 99:
                GetComponent<SpriteRenderer>().sprite = balloons[0];
                break;
            default:
                Debug.Log("invalid case number");
                break;
        }

    }
}

