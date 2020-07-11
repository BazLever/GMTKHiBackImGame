using System.Collections;
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
