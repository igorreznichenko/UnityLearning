using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehavior : MonoBehaviour
{
    [Range(1f, 10f)]
    public float speed = 4f;
    public float force = 100;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(new Vector3(0, 0, force));
       
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(new Vector3(-force / 2, 0, 0));

        if (Input.GetKey(KeyCode.D))
            rb.AddForce(force / 2,0, 0);
    }
}
