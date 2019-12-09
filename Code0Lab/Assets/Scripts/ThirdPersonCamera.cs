using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour  // create Third Person Camera Class
{
    public Transform lookAt;               //allows to set what the camera will look at
    public Transform camTransform;             

    private Camera cam;                   //references the camera

    private float distance = 10.0f;      //sets distance from lookAt object
    private float currentX = 0.0f;       //sets current X position of camera
    private float currentY = 30.0f;      //sets current Y position of camera
    private float sensitivityX = 8f;     //sets speed of camera rotation on X
    private float sensitivityY = 5f;     //sets speed of camera rotation on Y
    private void Start()
    {
        camTransform = transform;
        cam = Camera.main;              // gets camera in scene, check for Display 1 
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivityX;     //sets camera control on  X-axis to mouse X and sensitivity
        currentY -= Input.GetAxis("Mouse Y") * sensitivityY;     //sets camera control on Y-axis to Mouse Y and sensitivity
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);                      //update and change current camera position based on X, Y, and Z minus set distance
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);   //maintain LookAt target as camera center point
        camTransform.position = lookAt.position + rotation * dir;        //update camera rotation and position based off lookAt target's center point
        camTransform.LookAt(lookAt.position);                            //update position of the LookAt target
    }
}
