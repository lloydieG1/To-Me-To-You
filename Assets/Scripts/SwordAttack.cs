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
    
    Animator myAnimator;

    public float damage = 1f;
    
    void Start(){
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myAnimator.SetTrigger("SwingSword");
        
            Debug.Log("click");
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++){
                enemiesToDamage[i].GetComponent<DamageableCharacter>().OnHit(damage);
                }
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
