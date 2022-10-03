using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStart : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10f; //controls speed of ball
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //set intial direction and velocity of ball
        //normalize sets magnitude of vector to 1, which makes it consistent with velocity in Update()
        Vector2 initialDirection = new Vector2(-1f, -1f);
        initialDirection.Normalize();
        rb.AddForce(initialDirection * speed); 
    }

    void Update()
    {
        //fixes the speed of ball to value determined by "speed"
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed);
    }
}
