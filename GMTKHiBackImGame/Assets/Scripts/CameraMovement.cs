using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    float mouseXValue;
    float mouseYValue;

    private GameObject player;

    public float cameraSensitivity;

    //public bool headCheck;

    //public GameObject cameraObject;


    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        mouseYValue = Mathf.Min(85, Mathf.Max(-85, mouseYValue + Input.GetAxis("Mouse Y")));
        mouseXValue += Input.GetAxis("Mouse X");

        player.transform.localRotation = Quaternion.Euler(0, mouseXValue, 0);
        transform.localRotation = Quaternion.Euler(-mouseYValue, 0, 0);





        /*
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

        

        if (cameraObject.transform.rotation.eulerAngles.x >= 85)
        {
            Debug.Log("Player is looking below 85 degrees");
            transform.rotation = Quaternion.Euler(85, cameraObject.transform.rotation.eulerAngles.y, cameraObject.transform.rotation.eulerAngles.z);
        }

        if (cameraObject.transform.rotation.eulerAngles.x <= -85)
        {
            Debug.Log("Player is looking below 85 degrees");
            transform.rotation = Quaternion.Euler(-85, cameraObject.transform.rotation.eulerAngles.y, cameraObject.transform.rotation.eulerAngles.z);
        }
        */



    }
}
