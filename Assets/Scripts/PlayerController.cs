using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SwitchCharacter switchCharacter;
    GameObject myGameObject;

    private void Start()
    {
        myGameObject = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // switch character command
        if (Input.GetKeyDown("space"))
        {
            switchCharacter.SwitchPlayer(myGameObject);
            switchCharacter.currentPlayer.GetComponent<PlayerController>().enabled = true;
            switchCharacter.currentPlayer.GetComponent<PlayerMovement>().enabled = true;
        }
    }
}
