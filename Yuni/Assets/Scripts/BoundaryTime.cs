using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoundaryTime : MonoBehaviour
{
    public Text Timetext;
    public GameObject Player;
    
   // public float countText = 
    private void FixedUpdate()
    {
        Timetext.text = "00 : 0";
    }
}
