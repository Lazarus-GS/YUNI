using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public bool Dead = false;
    public bool IsDead = false;
    public GameObject DeathScreen;

    public GameObject Bombtip;
    public GameObject Collectibletip;

    public AudioSource collide1;
    public AudioSource collide2;
    


    //Vector3 lastVelocity;

    private void Awake()
    {
        _rBody = GetComponent<Rigidbody>();
    }


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        DeathScreen.SetActive(false);
        Bombtip.SetActive(false);
        Collectibletip.SetActive(false);
    }

    
    void Update()
    {
        ProcessInput();

        //Death Screen
        // Debug.Log("New" + IsDead);
        IsDead = GameObject.Find("Player Variant").GetComponent<PlayerControl>().Dead;

        if (IsDead)
        {
            
            Time.timeScale = 0f;
            DeathScreen.SetActive(true);
            
        }

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
            //Debug.Log("Dead");
            Dead = true;
        }
      

        
    }
    //Bomb Traps
    private void OnCollisionEnter(Collision collision)
    {
        //Bomb Traps
        
        if (collision.collider.tag == "Bomb")
        {
            TakeDamage(currentHealth);
            //FindObjectOfType<GameManager>().deathScreen();
            
        }
        if(collision.collider.tag == "Terrain")
        {
            var velocity = _rBody.velocity;
            float speed = velocity.magnitude;
            if (speed >= 3.0f)
            {
                //Debug.Log(speed);
                TakeDamage(collisionDamage);
                collide1.Play();


            }
            

        }
     
        
        
    }

    //Taking Damage
    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Terrain Collision doesn't make loose control
        if (other.tag != "Terrain")
        {
            noControls = false;
            
        }

        if(other.tag == "Door1")
        {
            SceneManager.LoadScene("Level 2");
        }
        
        


        //landing stations
        if (other.tag == "Lander")
        {
            GameObject.Find("Vale(Object)").GetComponent<CapsuleCollider>().material.bounciness = 0f;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        //Boundary
        if (other.tag == "Boundary")
        {
            countdownTime -= 1 * Time.deltaTime;
            Debug.Log(countdownTime.ToString("0"));
            if (countdownTime <= 0)
            {
                Dead = true;           
            }
            
            
        }

        //Tips
        if (other.tag == "Bombtip")
        {
            Bombtip.SetActive(true);

        }
        if (other.tag == "Collectibletip")
        {
            Collectibletip.SetActive(true);

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

        //Tips
        if (other.tag == "Bombtip")
        {
            Bombtip.SetActive(false);
            
        }
        if (other.tag == "Collectibletip")
        {
            Collectibletip.SetActive(false);

        }

    }

    //Deathscreen Controls

    public void Rerty()
    {
        /*DeathScreen.SetActive(false);
        Time.timeScale = 1f;
        IsDead = false;*/
    }

    public void Restart()
    {
        Debug.Log("Restarting");
        //FindObjectOfType<GameManager>().restartGame();
        //SceneManager.LoadScene("Level1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Debug.Log("Loading Menu...");
        FindObjectOfType<GameManager>().mainMenu();
    }

    public void quittingGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    IEnumerator timeDelay()
    {
        yield return new WaitForSeconds(2);

    }


}
