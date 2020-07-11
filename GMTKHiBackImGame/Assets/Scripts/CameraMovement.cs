using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    float mouseXValue;
    float mouseYValue;
    float mouseZValue;

    private GameObject player;

    public float cameraSensitivity;

    bool quickTurning;


    int turns = 9;


    float value;


    private void Start()
    {
        quickTurning = false;
        player = GameObject.Find("Player");

    }

    void Update()
    {
        mouseYValue = Mathf.Min(85, Mathf.Max(-85, mouseYValue + Input.GetAxis("Mouse Y")));
        mouseXValue += Input.GetAxis("Mouse X");

        player.transform.localRotation = Quaternion.Euler(0, mouseXValue, 0);
        transform.localRotation = Quaternion.Euler(-mouseYValue, 0, 0);



        if (Input.GetMouseButtonDown(1) && quickTurning == false)
        {
            quickTurning = true;
            Debug.Log("Turning!");
        }

        if (quickTurning)
        {
            quickTurn();
        }



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


    void quickTurn()
    {
        if (turns != 0)
        {
            turns -= 1;
            mouseXValue += 20;
        } else if (turns == 0)
        {
            quickTurning = false;
            turns = 9;
            Debug.Log("Finished Turning!");
        }
        
        /*
        value += 100 * Time.deltaTime;
        if (value < 180)
        {
            mouseXValue += value;
        } else if (value > 180)
        {
            quickTurning = false;
        }
        */
    }

}
