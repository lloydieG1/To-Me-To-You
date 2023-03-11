using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCollider : MonoBehaviour
{
    public Collider2D teleportTarget; // the collider to teleport the balloon to

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Balloon") && other.GetComponent<HasTeleported>().hasTeleported == false)
        {
            other.GetComponent<HasTeleported>().hasTeleported = true;
            // Teleport the balloon to the teleport target
            other.transform.position = new Vector2(other.transform.position.x, teleportTarget.transform.position.y);

            // Flip the balloon's velocity
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            Debug.Log("in vel: " + rb.velocity);
            Debug.Log("out vel: " + -rb.velocity);
            rb.velocity = -rb.velocity;
        }
    }

    private void OnDrawGizmos()
    {
        #if UNITY_EDITOR
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider2D>().size);
        #endif
    }
}

