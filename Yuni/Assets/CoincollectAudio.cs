using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoincollectAudio : MonoBehaviour
{
    public AudioSource Coinsound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Coinsound.Play();
        }
    }


}
