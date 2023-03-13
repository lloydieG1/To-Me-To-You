using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DamageableCharacter : MonoBehaviour, Damageable {

    Rigidbody2D rb;
    Collider2D physicsCollider;
    [SerializeField] float _health = 3f;
    SpriteRenderer spriteRenderer;
    public GameObject timer;
    public LevelLoader levelLoader;

    private AudioManager audioManager;

    // public PlayerMovement playerMovement;

    private void Start() {
        audioManager = FindObjectOfType<AudioManager>();
        rb = GetComponent<Rigidbody2D>();
        // playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public float Health {
        set{
            if(value < _health){
                if (gameObject.tag == "Player"){
                    audioManager.Play("PlayerDamage");
                    // when player takes damage

                } else if (gameObject.tag == "Enemy"){
                    // when enemy takes damage
                }
                
            }
            _health = value;
            Debug.Log(_health);
            if(_health <= 0 && gameObject.tag == "Enemy"){
                //when enemy dies
                audioManager.Play("EnemyDeath");

                // increment kill score
                PlayerPrefs.SetInt("kills", PlayerPrefs.GetInt("kills") + 1);
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

        Debug.Log("REE SCORE: " + timer.GetComponent<Timer>().timeElapsed);
        PlayerPrefs.SetInt("time", timer.GetComponent<Timer>().timeElapsed);
        SceneManager.LoadScene("GameOver");

        // levelLoader.LoadNextLevel();
    }

    IEnumerator ChangeColor() {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red; // Change to the desired color
        yield return new WaitForSeconds(0.3f); // Change to the desired duration
        spriteRenderer.color = Color.white; // Change back to the original color
    }

    
}