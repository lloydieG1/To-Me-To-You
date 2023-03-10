using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount){
        health -= damageAmount;
        if(transform.localScale.x > 0){
            
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
