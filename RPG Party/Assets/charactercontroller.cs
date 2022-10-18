using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class charactercontroller : MonoBehaviour
{
    public float movementspeed = 10;
    public GameManagerS GameManager;
    public Canvas prompt;
    private void Start()
    {
        GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManagerS>();
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            prompt.gameObject.SetActive(false);


        }
    }

    public void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * movementspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * movementspeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * movementspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * movementspeed * Time.deltaTime);

        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "enemy")
        {
            prompt.gameObject.SetActive(true);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "enemy")
        {
            prompt.gameObject.SetActive(false);

        }
    }
}
