using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private Rigidbody _rBody;

    private float verticalThrust = 25f;
    private float horizontalThrust = 15f;

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

        if (Input.GetKey(KeyCode.Space)) // Thrust(Verticle Control)
        {
            _rBody.AddForce(Vector3.up * verticalThrust);
        }

        //Horizontal Contrlon and Rotation Control
        if (Input.GetKey(KeyCode.A))
        {

            _rBody.AddForce(-Vector3.right * horizontalThrust);

            transform.Rotate(Vector3.forward * 1);

        }

        if (Input.GetKey(KeyCode.D))
        {

            _rBody.AddForce(Vector3.right * horizontalThrust);

            transform.Rotate(-Vector3.forward * 1);

        }

        //balance
        else if (transform.eulerAngles.z < 15)
        {
            transform.Rotate(-Vector3.forward*0.2f);
        }

        else if (transform.eulerAngles.z > 345)
        {
            transform.Rotate(Vector3.forward*0.2f);
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

}
