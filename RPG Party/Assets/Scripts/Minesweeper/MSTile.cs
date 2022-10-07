using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSTile : MonoBehaviour
{
    public bool mine;
    public GameObject theManager;
    private MSManagerS theAstManager;
    public int iCoord;
    public int jCoord;
    public Sprite[] emptyTextures;
    public Sprite mineTexture;
    public Sprite flagTexture;
    public Sprite tileTexture;
    
    void Start()
    {
        theManager = GameObject.FindGameObjectWithTag("GameController");
        theAstManager = theManager.GetComponent<MSManagerS>();
    }

    void OnMouseUpAsButton()
    {
        if (isCovered())
        {
            if (mine)
            {
                theAstManager.revealMines();
            }
            else
            {
                loadTexture(0);
            }
        }
    }

    void OnMouseOver()
    {
        //Use for non left mouse button clicks
        if (Input.GetMouseButtonDown(1)){
            if (GetComponent<SpriteRenderer>().sprite == tileTexture || GetComponent<SpriteRenderer>().sprite == flagTexture)
            {
                flagPlant();
            }
        }

    }

    void flagPlant()
    {
        if(GetComponent<SpriteRenderer>().sprite.texture.name == "FlagTile")
        {
            GetComponent<SpriteRenderer>().sprite = tileTexture;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = flagTexture;
        }
    }

    public void loadTexture(int num)
    {
        if (mine)
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        else
            GetComponent<SpriteRenderer>().sprite = emptyTextures[theAstManager.getAdjCount(iCoord,jCoord)];
    }
    
    public bool isCovered()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "Tile";
    }
}
