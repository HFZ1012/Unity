using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFixedUpdate : MonoBehaviour
{

    public float speed = 1;
    public float force = 1;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity += new Vector3(0, 0, 1) * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(0, 0, 1) * force);
    }
}
}