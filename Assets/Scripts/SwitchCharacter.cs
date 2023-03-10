using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour {

    // references to controlled game objects
    public GameObject player1, player2;

    // variable contains which player is on and active
    public GameObject currentPlayer;

    // Use this for initialization
    void Start () {
        // disable all players
        player1.GetComponent<PlayerMovement>().enabled = false;
        player2.GetComponent<PlayerMovement>().enabled = false;

        // set the first player as the current player
        currentPlayer = player1;
        currentPlayer.GetComponent<PlayerMovement>().enabled = true;
        player2.GetComponent<PlayerController>().enabled = false;
    }

    // public method to switch players by pressing UI button
    public void SwitchPlayer(GameObject player)
    {
        // switch to player 2
        if (player == player1) {
            Debug.Log("switching to player 2");
            currentPlayer.GetComponent<PlayerMovement>().enabled = false;
            currentPlayer.GetComponent<PlayerController>().enabled = false;
            currentPlayer = player2;
        }

        // switch to player 1
        if (player == player2) {
            Debug.Log("switching to Player 1");
            currentPlayer.GetComponent<PlayerMovement>().enabled = false;
            currentPlayer.GetComponent<PlayerController>().enabled = false;
            currentPlayer = player1;
        }
    }

}