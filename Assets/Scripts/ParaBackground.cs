using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParaBackground : MonoBehaviour
{
    public float parallaxFactor = 0.5f; // Adjust this value to change the parallax speed.

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    private void Update()
    {
        float deltaX = cameraTransform.position.x - lastCameraPosition.x;
        float deltaY = cameraTransform.position.y - lastCameraPosition.y;

        transform.position += new Vector3(deltaX * parallaxFactor, deltaY * parallaxFactor, 0f);

        lastCameraPosition = cameraTransform.position;
    }
}