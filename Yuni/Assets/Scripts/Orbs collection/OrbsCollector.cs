using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbsCollector : MonoBehaviour
{
    public GameObject collectibles;
    public static int collection;


    public void FixedUpdate()
    {
        collectibles.GetComponent<Text>().text = collection.ToString();
    }


}
