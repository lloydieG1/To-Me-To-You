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

    public Image oxygenBar;
    private float width;
    private float initialOxygenLevel;

    Color currentColor;
    Color targetColor;
    Color newColor;

    private void Start() {
        initialOxygenLevel = oxygenLevel;
    }

    // Update is called once per frame
    void Update()
    {
        // currentColor = oxygenBar.color;
        // targetColor = oxygenGradient.Evaluate(oxygenLevel / 100f);
        // newColor = Color.Lerp(currentColor, targetColor, Time.deltaTime * colorChangeSpeed);

        // oxygenBar.color = newColor;
        
        if(oxygenLevel/initialOxygenLevel < 0.5) {
            oxygenBar.color = new Color(255,255,0);
        } else if(oxygenLevel/initialOxygenLevel < 0.25) {
            oxygenBar.color = new Color(255,0,0);
        }
        
        // Deplete oxygen based on depletion rate
        oxygenLevel -= oxygenDepletionRate * Time.deltaTime;


        // update oxygen display
        width = oxygenLevel;

        oxygenBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);

        // Clamp oxygen level to be between 0 and 100
        oxygenLevel = Mathf.Clamp(oxygenLevel, 0f, 100f);
        

    }

    public void AddOxygen(float amount)
    {
        // Add oxygen to player's oxygen level
        oxygenLevel += amount;

        // Clamp oxygen level to be between 0 and 100
        oxygenLevel = Mathf.Clamp(oxygenLevel, 0f, 100f);
    }
}

