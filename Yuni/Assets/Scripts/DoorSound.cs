using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public AudioSource Doorsound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" )
        {
            Doorsound.Play();
        }
    }


}
