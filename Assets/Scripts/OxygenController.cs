using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OxygenController : MonoBehaviour
{
    public float oxygenLevel = 100f;   // starting oxygen level
    public float oxygenDepletionRate = 1f;   // rate at which oxygen depletes per second
    public float oxygenGainRate = 2f;    // rate at which oxygen refills per second

    public Image oxygenBar;
    private float width;

    private void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
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

