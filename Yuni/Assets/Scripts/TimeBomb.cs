using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBomb : MonoBehaviour
{
    [SerializeField] private float explotionRadius = 5;
    [SerializeField] private float explotionForce = 500;

   // [SerializeField] private Animator bombAnimation;

    public float delay = 3f;
    public float countdownTime = 3f;
    public AudioSource Bombsound;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
           StartCoroutine(timeDelay());  
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
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
        countdownTime = delay;
    }

    private void Explode()
    {
        var surroundingObjects = Physics.OverlapSphere(transform.position, explotionRadius);

        foreach (var obj in surroundingObjects)
        {
            var rb = obj.GetComponent<Rigidbody>();
            if (rb == null) continue;

            rb.AddExplosionForce(explotionForce, transform.position, explotionRadius);

        }

        //bombAnimation.SetBool("Explodeanimation",true);
        Destroy(gameObject);
        
    }

    IEnumerator timeDelay()
    {
        yield return new WaitForSeconds(delay);
        Bombsound.Play();
        Explode();

    }
}
