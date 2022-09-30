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
        for (int i = 0; i < w; i++)
        {
            tempX = i - (w / 2);
            for (int j = 0; j < h; j++) {
                tempY = j - (h / 2);
                newTile = Instantiate(tilePrefab, new Vector3(tempX, tempY, 0), Quaternion.identity);
                newTile.GetComponent<MSTile>().mine = Random.value < 0.15;
                newTile.GetComponent<MSTile>().iCoord = i;
                newTile.GetComponent<MSTile>().jCoord = j;

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

    public int getAdjCount(int a,int b)
    {
        int answer = 0;
        for (int i = 0; i < 8; i++)
        {
            switch (i)
            {
                case 0: //Right of tile
                    if (a + 1 != w) { if (theGridio[a + 1, b].mine) { answer++; } }
                    break;
                case 1: //Down Right
                    if((a+1 != w) && (b != 0)) { if(theGridio[a+1,b-1].mine) { answer++; } }
                    break;
                case 2: // Down
                    if (b != 0) { if (theGridio[a, b-1].mine) { answer++; } }
                    break;
                case 3: //Down Left
                    if ((a != 0) && (b != 0)) { if (theGridio[a - 1, b - 1].mine) { answer++; } }
                    break;
                case 4: //Left of tile
                    if (a != 0) { if (theGridio[a - 1, b].mine) { answer++; } }
                    break;
                case 5: //Up Left
                    if ((a != 0) && (b+1 != h)) { if (theGridio[a - 1, b + 1].mine) { answer++; } }
                    break;
                case 6: // Up
                    if (b+1 != h) { if (theGridio[a, b + 1].mine) { answer++; } }
                    break;
                case 7: //Up Right
                    if ((a+1 != w) && (b + 1 != h)) { if (theGridio[a + 1, b + 1].mine) { answer++; } }
                    break;
            }
        }
        return answer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
