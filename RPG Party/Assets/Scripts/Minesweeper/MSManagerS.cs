using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSManagerS : MonoBehaviour
{
    public GameObject tilePrefab;
    private GameObject newTile;
    float tempX;
    float tempY;

    public static int w = 8;
    public static int h = 8;
    public static MSTile[,] theGridio = new MSTile[w, h];

    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            tempX = i - (w / 2);
            for (int j = 0; j < 8; j++) {
                tempY = j - (h / 2);
                newTile = Instantiate(tilePrefab, new Vector3(tempX, tempY, 0), Quaternion.identity);
                newTile.GetComponent<MSTile>().mine = Random.value < 0.15;

                theGridio[i, j] = newTile.GetComponent<MSTile>();
            }
        }
    }

    public void revealMines()
    {
        foreach (MSTile spot in theGridio) {
            if (spot.mine) { spot.loadTexture(0); }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
