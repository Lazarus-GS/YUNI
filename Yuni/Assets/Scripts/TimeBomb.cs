using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBomb : MonoBehaviour
{
    [SerializeField] private float explotionRadius = 5;
    [SerializeField] private float explotionForce = 500;

    public float delay = 3f;



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag != "Untagged" && other.tag != "Bomb")
        {

         StartCoroutine(timeDelay());
         
            
        }
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

        Destroy(gameObject);
    }

    IEnumerator timeDelay()
    {
        yield return new WaitForSeconds(delay);
        Explode();
    }
}
