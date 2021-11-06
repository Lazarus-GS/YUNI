using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        OrbsCollector.collection += 1;
        Destroy(gameObject);
    }
}
