using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OxygenController : MonoBehaviour
{
    public float oxygenLevel;   // starting oxygen level
    public float oxygenDepletionRate;   // rate at which oxygen depletes per second
    public float oxygenGainRate;    // rate at which oxygen refills per second
    public float colorChangeSpeed;

    public GameObject oxygenUI;
    public GameObject timer;
    private OxygenBar oxygenBar;

    private float width;
    private float initialOxygenLevel;

    private AudioManager audioManager;

    Color currentColor;
    Color targetColor;
    Color newColor;
    int roundedPercentageDepleted;

    private void Start() {
        audioManager = FindObjectOfType<AudioManager>();
        initialOxygenLevel = oxygenLevel;

        oxygenBar = oxygenUI.GetComponent<OxygenBar>();

    }

    // Update is called once per frame
    void Update()
    {
        if(oxygenLevel <= 0) {
            Defeated();
        }

        roundedPercentageDepleted = Mathf.RoundToInt(oxygenLevel/initialOxygenLevel * 100); 

        // horrendous implementation of face animation
        switch (roundedPercentageDepleted)
        {
            case 100:
                oxygenBar.ChangeSprite(0);
                Debug.Log("100% remaining");
                break;
            case 75:
                oxygenBar.ChangeSprite(1);
                Debug.Log("75% remaining");
                break;
            case 50:
                oxygenBar.ChangeSprite(2);
                Debug.Log("50% remaining");
                break;
            case 25:
                oxygenBar.ChangeSprite(3);
                Debug.Log("20% remaining");
                break;
            case 10:
                audioManager.Play("LastBreath");
                oxygenBar.ChangeSprite(4);
                Debug.Log("10% remaining");
                break;
            case 0:
                oxygenBar.ChangeSprite(5);
                Debug.Log("5% remaining");
                break;
            default:
                Debug.Log("invalid case number");
                break;
        }
        
        // Deplete oxygen based on depletion rate
        oxygenLevel -= oxygenDepletionRate * Time.deltaTime;


        // Clamp oxygen level to be between 0 and 100
        oxygenLevel = Mathf.Clamp(oxygenLevel, 0f, 100f);
        

    }

    public void Defeated(){
        // What happens when the player is defeated
        Debug.Log("player dead");
        Debug.Log(timer.GetComponent<Timer>().timeElapsed);
        PlayerPrefs.SetInt("time", timer.GetComponent<Timer>().timeElapsed);
        SceneManager.LoadScene("GameOver");
    }

    public void AddOxygen(float amount)
    {
        Debug.Log("adding oxygen: " + oxygenLevel);

        // Add oxygen to player's oxygen level
        oxygenLevel += amount;

        // Clamp oxygen level to be between 0 and 100
        oxygenLevel = Mathf.Clamp(oxygenLevel, 0f, 100f);
    }
}

