using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gets input and scales by speed
        float translation = Input.GetAxis("Horizontal") * speed;

        //makes input over time instead of over frames (makes it frame independent)
        translation *= Time.deltaTime;

        //change position of paddle
        transform.Translate(translation, 0,0);
    }

}
