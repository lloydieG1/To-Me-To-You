using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasTeleported : MonoBehaviour
{
    public bool hasTeleported;

    // things can only teleport once
    private void Start() {
        hasTeleported = false;
    }
}
