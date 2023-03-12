using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public TMP_Text scoreText;

    void Start() {
        int score = PlayerPrefs.GetInt("time"); // Get score from PlayerPrefs
        Debug.Log("SCORE: " + score);
        scoreText.text = "Your Time: " + score.ToString(); // Display score on screen
    }
}
