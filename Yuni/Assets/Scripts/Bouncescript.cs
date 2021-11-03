using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncescript : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody _rBody;

    Vector3 lastVelocity;
    void Start()
    {
        
    }

    private void Awake()
    {
        _rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = _rBody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        _rBody.velocity = direction * Mathf.Max(speed, 30f);
    }

}
