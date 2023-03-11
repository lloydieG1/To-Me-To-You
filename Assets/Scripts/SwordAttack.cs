using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    

    public float damage = 1f;
    public float knockbackForce = 100f;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click");
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++){
                Debug.Log("stuff happening");
                    // Offset for collision detection changes the direction where the force is coming from
                Vector2 direction = (GetComponent<Collider2D>().transform.position - transform.position).normalized;

                    // Knockback is in direction of swordCollider towards collider
                Vector2 knockback = direction * knockbackForce;
                enemiesToDamage[i].GetComponent<DamageableCharacter>().OnHit(damage, knockback);
                }
            }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
