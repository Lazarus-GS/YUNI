using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow2 : MonoBehaviour
{

    public Transform target; //camera target
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFacter;
    void FixedUpdate()
    {
        Follow();
        /*if (transform.position.x <= -2f)
        {
            transform.position = new Vector3(-2f, transform.position.y, transform.position.z);
        }*/
        if (transform.position.x >= 69f)
        {
            transform.position = new Vector3(69f, transform.position.y, transform.position.z);
        }
    }

    private void Follow()
    {
        Vector3 targetPosition = target.position + offset; //Camera position
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFacter * Time.fixedDeltaTime); //Smoothing camera
        transform.position = smoothPosition;
    }
}
