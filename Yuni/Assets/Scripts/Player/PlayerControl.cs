using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private Rigidbody _rBody;
    private bool rightKeyPressed;
    private bool leftKeyPressed;
    private bool thrustKeypressd;

    public float verticalThrust = 45f;
    public float horizontalThrust = 15f;

    private void Awake()
    {
        _rBody = GetComponent<Rigidbody>();
    }


    void Start()
    {

    }


    void Update()
    {
        ProcessInput();

    }//Update

    private void ProcessInput()
    {

        if (Input.GetKey(KeyCode.W)) // Thrust(Verticle Control)
        {
            thrustKeypressd = true;

        }

        //Horizontal Contrlon and Rotation Control
        if (Input.GetKey(KeyCode.A))
        {
            leftKeyPressed = true;
        }
        else if (transform.eulerAngles.z < 15)
        {
            transform.Rotate(-Vector3.forward * 0.2f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rightKeyPressed = true;


        }
        //balance
        

        else if (transform.eulerAngles.z > 345)
        {
            transform.Rotate(Vector3.forward * 0.2f);
        }

        //lock
        if ((transform.eulerAngles.z > 10) && (transform.eulerAngles.z < 180))
        {
            transform.eulerAngles = new Vector3(0, 0, 10);
        }


        if ((transform.eulerAngles.z < 350) && (transform.eulerAngles.z > 180))
        {
            transform.eulerAngles = new Vector3(0, 0, 350);
        }


    }

    private void FixedUpdate()
    {
        if (thrustKeypressd == true)
        {
            _rBody.AddForce(Vector3.up * verticalThrust);
            thrustKeypressd = false;
        }

        if (rightKeyPressed == true)
        {
            _rBody.AddForce(Vector3.right * horizontalThrust);

            transform.Rotate(-Vector3.forward * 1);
            rightKeyPressed = false;
        }

        if (leftKeyPressed == true)
        {
            _rBody.AddForce(-Vector3.right * horizontalThrust);

            transform.Rotate(Vector3.forward * 1);
            leftKeyPressed = false;
        }

        


        
    }
}
