using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackTrigger : MonoBehaviour
{


private void OnCollisionEnter2D(Collision2D other) {
    var PlayerMovement = other.collider.GetComponent<PlayerMovement>();
    if(PlayerMovement != null && transform.tag == "Enemy"){
        PlayerMovement.Knockback(transform);
    }

    // var WalkToTarget = other.collider.GetComponent<WalkToTarget>();
    // if(WalkToTarget != null && transform.tag == "Sword"){
    //     WalkToTarget.Knockback(transform);
    // }
}
}
