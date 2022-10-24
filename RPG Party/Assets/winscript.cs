using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class winscript : MonoBehaviour
{
    public GameManagerS GameManager;
    // Start is called before the first frame update
    void Start()
    {
         GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManagerS>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D()
    {
              Debug.Log("Won!!!!!");
        
        //update player health
        GameManager.addScore(100);
        
        SceneManager.LoadScene("Overworld");
        //pausegame
        Time.timeScale = 0;
    }
}
