using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothSpeed = 0.125f; // the speed at which the camera follows the player
    public GameObject target;

    private Vector3 offset; // the offset between the camera and the player
    private Transform targetTransform; // the player's transform

    void Start()
    {
        targetTransform = target.transform;
        offset = transform.position - targetTransform.position; // calculate the initial offset
    }

    private void FixedUpdate() {
        Vector3 desiredPosition = targetTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(targetTransform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, transform.position.y, transform.position.z);
    }
}

