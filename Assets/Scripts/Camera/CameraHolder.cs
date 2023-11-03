using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [SerializeField] private Transform playerTrasnform;
    private Vector3 initialRotation;

    private void Awake()
    {
        initialRotation = transform.eulerAngles;
    }

    void Update()
    {
        transform.position = new Vector3(playerTrasnform.position.x, playerTrasnform.position.y,
            playerTrasnform.position.z);

        transform.eulerAngles = new Vector3(playerTrasnform.eulerAngles.x, playerTrasnform.eulerAngles.y,
            0);

        transform.eulerAngles = new Vector3(playerTrasnform.eulerAngles.x + initialRotation.x,
            playerTrasnform.eulerAngles.y + initialRotation.y, 0);
    }
}
