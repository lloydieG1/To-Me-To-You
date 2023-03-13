using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KillScore : MonoBehaviour {
    public TMP_Text scoreText;

    void Start() {
        int kills = PlayerPrefs.GetInt("kills"); // Get score from PlayerPrefs
        Debug.Log("KILLS: " + kills);
        scoreText.text = "Your Kills: " + kills.ToString(); // Display score on screen
    }
}

