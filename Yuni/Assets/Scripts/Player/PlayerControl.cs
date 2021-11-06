using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private Rigidbody _rBody;
    private bool rightKeyPressed;
    private bool leftKeyPressed;
    private bool thrustKeypressd;

    public float countdownTime;

    private bool isGrounded;
    [SerializeField] private Transform groundCheckTransform = null;

    public float verticalThrust = 45f;
    public float horizontalThrust = 15f;
    private bool noControls = true;

    public int maxHealth = 90;
    public int currentHealth;
    public HealthBar healthBar;
    public int collisionDamage;

    public int numberOfOrbs = 0;


    //Vector3 lastVelocity;

    private void Awake()
    {
        _rBody = GetComponent<Rigidbody>();
    }


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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

        //Horizontal Control and Rotation Control
        if (Input.GetKey(KeyCode.A))
        {
            leftKeyPressed = true;
        }

        //balance
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
        
        

        //thruster
        if (thrustKeypressd == true)
        {
            _rBody.AddForce(Vector3.up * verticalThrust);
            thrustKeypressd = false;
        }

        //When grounded nothing works
       // if (isGrounded)
       // {
       //     return;
       //}
 
            if((Physics.OverlapSphere(groundCheckTransform.position, 0.2f).Length == 2) && (noControls == true))
            {
                return;
            }


        //movement controls
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

        if (currentHealth <= 0)
        {
            FindObjectOfType<GameManager>().deathScreen();
        }
      

        
    }
    //Bomb Traps
    private void OnCollisionEnter(Collision collision)
    {
        //Bomb Traps
        
        if (collision.collider.tag == "Bomb")
        {
            TakeDamage(90);
            //FindObjectOfType<GameManager>().deathScreen();
            
        }
        if(collision.collider.tag == "Terrain")
        {
            var velocity = _rBody.velocity;
            float speed = velocity.magnitude;
            if (speed >= 3.0f)
            {
                Debug.Log(speed);
                TakeDamage(collisionDamage);   
            }
      
        }
      //landing stations
        if(collision.collider.tag =="Lander")
        {
            GameObject.Find("Vale(Object)").GetComponent<CapsuleCollider>().material.bounciness = 0f;
        }
        
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Terrain")
        {
            noControls = false;
        }

        if (other.tag == "Lander")
        {
            GameObject.Find("Vale(Object)").GetComponent<CapsuleCollider>().material.bounciness = 0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Boundary")
        {
            countdownTime -= 1 * Time.deltaTime;
            Debug.Log(countdownTime.ToString("0"));
            if (countdownTime <= 0)
            { 
                FindObjectOfType<GameManager>().deathScreen();
            }
            
            
        }
        

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag != "Terrain")
        {
            noControls = true;
        }
        
        if (other.tag == "Boundary")
        {
            countdownTime = 3;
        }
        if (other.tag == "Lander")
        {
            GameObject.Find("Vale(Object)").GetComponent<CapsuleCollider>().material.bounciness = 1f;
        }

    }



}
