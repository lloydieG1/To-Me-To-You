using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public int damage;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            DamageableCharacter damageable = collision.gameObject.GetComponent<DamageableCharacter>();
            damageable.OnHit(damage);
        } else if (collision.gameObject.CompareTag("Ground")) {
            Destroy(gameObject);
        }
    }

}
