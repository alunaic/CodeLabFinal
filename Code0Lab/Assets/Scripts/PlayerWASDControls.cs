using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWASDControls : MonoBehaviour
{
    Rigidbody rb; //declare a reference for the rigidbody

    public GameObject cam; //connect to a camera object
    public float force = 100.0f; //create a force to push the playerObject
    public float jumpHeight = 15f; // create a force for player jump
    public bool isGrounded; //check to see if player is on an object tagged ground 
   

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //get the rigidbody from this playerObject
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider != null){ // check if object is not in contact with another collider
        isGrounded = false; // set Grounded to false
        }
    }

    void Update()
    {
        bool hasInput = false; //create local variable to track whether there is user input


        if (Input.GetKey(KeyCode.W))
        { //if the W is pressed
            Vector3 cameraforward = cam.transform.forward;
            cameraforward.y = 0;
            cameraforward = Vector3.Normalize(cameraforward);
            rb.AddForce(cameraforward * force);
            hasInput = true; //the user has pressed a key
        }

        if (Input.GetKey(KeyCode.S))
        { //if the S is pressed
            Vector3 cameraforward = cam.transform.forward;
            cameraforward.y = 0;
            cameraforward = Vector3.Normalize(cameraforward);
            rb.AddForce(cameraforward * -force);
            hasInput = true; //the user has pressed a key
        }

        if (Input.GetKey(KeyCode.A))
        { //if the A is pressed
            Vector3 cameraright = cam.transform.right;
            cameraright.y = 0;
            cameraright = Vector3.Normalize(cameraright);
            rb.AddForce(cameraright * -force);
            hasInput = true; //the user has pressed a key
        }

        if (Input.GetKey(KeyCode.D))
        {//if the D is pressed
            Vector3 cameraright = cam.transform.right;
            cameraright.y = 0;
            cameraright = Vector3.Normalize(cameraright);
            rb.AddForce(cameraright * force);
            hasInput = true; //the user has pressed a key
        }
       
        if (!Input.anyKey)
        { //if the user hasn't pressed a key
            rb.velocity = rb.velocity * 1.0f; //decrease velocity
        }

        RaycastHit hit; // raycast outwards from object position
            Physics.Raycast(gameObject.transform.position, Vector3.down, out hit, 1.5f);

            if (Input.GetKey(KeyCode.Space))
            {
                    rb.AddForce(Vector3.up * jumpHeight);
               
            }
    }
   

}
