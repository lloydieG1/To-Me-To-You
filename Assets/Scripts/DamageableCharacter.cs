using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCharacter : MonoBehaviour, Damageable {

    Rigidbody2D rb;
    Collider2D physicsCollider;
    [SerializeField] float _health = 3f;
    SpriteRenderer spriteRenderer;
    public LevelLoader levelLoader;
    // public PlayerMovement playerMovement;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        // playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public float Health {
        set{
            if(value < _health){
                // Stuff that happens when damage is taken
            }
            _health = value;
            Debug.Log(_health);
            if(_health <= 0 && gameObject.tag != "Player"){
                // when something that isnt a player dies
                Destroy(gameObject);
            }
            if(_health <= 0 && gameObject.tag == "Player"){
                // when the player dies
                Defeated();
            }
        }

        get{
            return _health;
        }

    }

    public void OnHit(float damage){
        Health -= damage;
        // rb.AddForce(knockback, ForceMode2D.Impulse);
        StartCoroutine(ChangeColor());
        // playerMovement.lockMovement = true;
    }

    public void Defeated(){
        // What happens when the player is defeated
        Debug.Log("player dead");
        // levelLoader.LoadNextLevel();
    }

    IEnumerator ChangeColor() {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red; // Change to the desired color
        yield return new WaitForSeconds(0.3f); // Change to the desired duration
        spriteRenderer.color = Color.white; // Change back to the original color
    }

    
}