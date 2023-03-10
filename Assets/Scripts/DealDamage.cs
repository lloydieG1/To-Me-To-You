using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Damage");
        if(collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemyComponent)){
            enemyComponent.TakeDamage(1);
            enemyComponent.knockBack(3);
        }
    }
}
