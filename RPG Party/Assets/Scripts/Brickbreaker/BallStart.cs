using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStart : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10f; //controls speed of ball
    public GameObject gameController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //set intial direction of ball
        Vector2 initialDirection = new Vector2(-1f, -1f);
        rb.AddForce(initialDirection);

        gameController = GameObject.Find("GameController");
    }

    void Update()
    {
        //fixes the speed of ball to value determined by "speed"
        rb.velocity = rb.velocity.normalized * speed;
        
        //Debug.Log(rb.velocity.ToString());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //update score when ball hits brick
        if (collision.gameObject.tag == "Brick")
        {
            Debug.Log("collision");
            gameController.GetComponent<GameControllerScript>().ChangeScore();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Death Floor")
        {
            gameController.GetComponent<GameControllerScript>().Lost();
        }
    }
}
