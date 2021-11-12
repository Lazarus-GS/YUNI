using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{

    public ParticleSystem ThrusterLeft, ThrusterRight;
    
    void Start()
    {
        
    }

   
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)) // All Particles - On
        {
            ThrusterLeft.Play();
            ThrusterRight.Play();

        }
        else
        {
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                ThrusterRight.Play();
                ThrusterLeft.Play();

            }

            else if (Input.GetKey(KeyCode.A))
            {
                ThrusterRight.Play();
                ThrusterLeft.Stop();

            }

            else if (Input.GetKey(KeyCode.D))
            {
                ThrusterLeft.Play();
                ThrusterRight.Stop();
            }

            else  //All Particles - off
            {
                ThrusterRight.Stop();
                ThrusterLeft.Stop();
            }
        } 
    }
}
