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
