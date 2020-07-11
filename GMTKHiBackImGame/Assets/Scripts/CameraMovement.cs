﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    float mouseXValue;
    float mouseYValue;

    public float cameraSensitivity;

    public bool headCheck;


    
    void Update()
    {

        mouseXValue = Input.GetAxis("Mouse X");
        mouseYValue = Input.GetAxis("Mouse Y");

        /*
        if (transform.rotation.eulerAngles.x >= 85)
        {
            Debug.Log("Player is looking below 85 degrees");
            transform.rotation = Quaternion.Euler(85, 0, 0);
        }
        */

        if (mouseXValue != 0 && headCheck == false)
        {
            transform.Rotate(Vector3.up * mouseXValue * cameraSensitivity * Time.deltaTime);
        }

        if (mouseYValue != 0 && headCheck == true)
        {
            transform.Rotate(Vector3.right * -mouseYValue * cameraSensitivity * Time.deltaTime);
        }

    }
}
