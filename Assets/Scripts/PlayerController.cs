﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    [Tooltip("m/s")][SerializeField] float xSpeed = 4f;

    [Header("Movement Factors")]

    [SerializeField] float pitchFactor = -2.3f;
    [SerializeField] float controlPitchFactor = -20f;

    [SerializeField] float yawFactor = 2.5f;
    [SerializeField] float rollFactor = 20f;

    float horiz;
    float vert;

    bool isControlEnabled = true;

    void Start()
    {
        
    }

    

    

    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
       

    }

    private void ProcessTranslation()
    {
        horiz = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = horiz * xSpeed * Time.deltaTime;         // Offset = how much to move the ship every frame

        vert = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = vert * xSpeed * Time.deltaTime;

        // x and y axis have switched due to correction in model direction

        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(yOffset + transform.localPosition.y, -4.5f , 4.5f), Mathf.Clamp(xOffset + transform.localPosition.z, -12, 12));
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * pitchFactor + vert * controlPitchFactor;


        float yaw = transform.localPosition.z * yawFactor;


        float roll = horiz * rollFactor;


        transform.localRotation = Quaternion.Euler(roll, yaw, pitch);
        
    }

    void OnPlayerDeath()  // Called by string reference
    {
        isControlEnabled = false;
    }

 
}
