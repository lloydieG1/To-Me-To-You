using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OxygenController : MonoBehaviour
{
    public float oxygenLevel;   // starting oxygen level
    public float oxygenDepletionRate;   // rate at which oxygen depletes per second
    public float oxygenGainRate;    // rate at which oxygen refills per second
    public float colorChangeSpeed;

    public GameObject oxygenUI;
    private OxygenBar oxygenBar;

    private float width;
    private float initialOxygenLevel;

    Color currentColor;
    Color targetColor;
    Color newColor;
    int roundedPercentageDepleted;

    private void Start() {
        initialOxygenLevel = oxygenLevel;

        oxygenBar = oxygenUI.GetComponent<OxygenBar>();

    }

    // Update is called once per frame
    void Update()
    {
        roundedPercentageDepleted = Mathf.RoundToInt(oxygenLevel/initialOxygenLevel * 100); 

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

    public void AddOxygen(float amount)
    {
        Debug.Log("adding oxygen: " + oxygenLevel);

        // Add oxygen to player's oxygen level
        oxygenLevel += amount;

        // Clamp oxygen level to be between 0 and 100
        oxygenLevel = Mathf.Clamp(oxygenLevel, 0f, 100f);
    }
}

