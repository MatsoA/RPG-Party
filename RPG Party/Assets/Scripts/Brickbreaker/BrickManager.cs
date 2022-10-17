using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public GameObject brickPrefab;
    public GameObject GameController; 
    //private Gameobject brickHolder;

    //public GameController gameContoller;

    public int brickRows;
    public int brickColumns;

    public int totalBricks = 0;

    private float posX;
    private float posY;


    // Start is called before the first frame update
    void Start()
    {
        //brick generation
        for (int i = 0; i < brickRows; i++)
        {
            posX = 2 * i - (brickRows);
            for (int j = 0; j < brickColumns; j++)
            {
                posY = j - (brickColumns / 2);

                //randomly generate bricks
                if (Random.value < 0.35f) 
                {
                    Instantiate(brickPrefab, new Vector3(posX, posY, 0) + transform.position, Quaternion.identity, transform);
                    totalBricks++;
                }
            }
        }

        //send total number of bricks generated to GameController
        GameController.GetComponent<GameControllerScript>().remaining = totalBricks;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
