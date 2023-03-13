using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float firingRate = 1.0f;
    public float projectileSpeed = 1.0f;
    public float recoilForce = 0.5f;
    private PlayerMovement playerMovement;

    private string direction;
    private float nextFireTime = 0.0f;
    public float offsetY = 0.5f;
    private Vector2 offsetPos;

    private AudioManager audioManager;

    private void Start() {
        audioManager = FindObjectOfType<AudioManager>();
        
        playerMovement = GameObject.Find("IcePlayer").GetComponent<PlayerMovement>();
        Debug.Log(playerMovement.isFacing);
        if(playerMovement.isFacing == "Right") {
            Debug.Log("RIGHT");
            direction = "Right";
        } else if(playerMovement.isFacing == "Left") {
            GetComponent<SpriteRenderer>().flipX = true;
            Debug.Log("RIGHT");
            direction = "Left";
        }
    }

    void Update() {
        if (Time.time > nextFireTime) {
            nextFireTime = Time.time + 1.0f / firingRate;

            offsetPos = new Vector2(transform.position.x, transform.position.y + offsetY);

            GameObject projectile = Instantiate(projectilePrefab, offsetPos, transform.rotation);
            Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
            if(direction == "Right") {
                projectileRigidbody.velocity = transform.right * projectileSpeed;
            } else if(direction == "Left") {
                projectileRigidbody.velocity = -transform.right * projectileSpeed;
            }

            // play sound
            audioManager.Play("TurtleShoot");

            // Apply recoil force to the turret
            Rigidbody2D turretRigidbody = GetComponent<Rigidbody2D>();
            turretRigidbody.AddForce(transform.up * recoilForce, ForceMode2D.Impulse);

        }
    }
}
