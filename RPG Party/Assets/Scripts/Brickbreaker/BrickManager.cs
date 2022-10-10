using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public GameObject brickPrefab;
    //private Gameobject brickHolder;

    //public GameController gameContoller;

    public int brickRows;
    public int brickColumns;

    private float posX;
    private float posY;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < brickRows; i++)
        {
            posX = 2 * i - (brickRows);
            for (int j = 0; j < brickColumns; j++)
            {
                posY = j - (brickColumns / 2);

                Instantiate(brickPrefab, new Vector3(posX, posY, 0) + transform.position, Quaternion.identity, transform);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
