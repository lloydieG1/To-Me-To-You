using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public Text scoreText;

    void Start() {
        int score = PlayerPrefs.GetInt("score"); // Get score from PlayerPrefs
        scoreText.text = "Time: " + score.ToString(); // Display score on screen
    }
}
