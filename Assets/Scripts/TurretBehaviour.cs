using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float firingRate = 1.0f;
    public float projectileSpeed = 1.0f;
    public float recoilForce = 0.5f;

    private float nextFireTime = 0.0f;
    public float offsetY = 0.5f;
    private Vector2 offsetPos;

    void Update() {
        if (Time.time > nextFireTime) {
            nextFireTime = Time.time + 1.0f / firingRate;

            offsetPos = new Vector2(transform.position.x, transform.position.y + offsetY);

            GameObject projectile = Instantiate(projectilePrefab, offsetPos, transform.rotation);
            Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
            projectileRigidbody.velocity = transform.right * projectileSpeed;

            // Apply recoil force to the turret
            Rigidbody2D turretRigidbody = GetComponent<Rigidbody2D>();
            turretRigidbody.AddForce(transform.up * recoilForce, ForceMode2D.Impulse);

        }
    }
}
