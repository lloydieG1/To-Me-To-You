using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour {
    public TMP_Text timerText; // Text object to display timer
    public int timeElapsed = 0; // Time elapsed so far
    public GameObject player; // Flag to check if player is alive
    public GameObject oxygenController; 
    private int score = 0; // Score to display on game over screen

    void Start() {
        timerText = GetComponent<TMP_Text>();
        InvokeRepeating("IncreaseTime", 1f, 1f); // Call IncreaseTime() every second
    }

    void IncreaseTime() {
        timeElapsed++;
        score++;
        timerText.text = "Time: " + timeElapsed.ToString(); // Update timer display
    }
}