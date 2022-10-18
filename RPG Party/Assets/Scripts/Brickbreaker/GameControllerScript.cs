using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameControllerScript : MonoBehaviour
{
    public GameManagerS GameManager;

    public TextMeshProUGUI scoreText;
    public int remaining;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManagerS>();
    }

    // Update is called once per frame
    void Update()
    {
       scoreText.text = remaining.ToString();

       if (remaining == 0)
        {
            Won();
        }
    }

    public void ChangeScore()
    {
        Debug.Log("minus 1");
        remaining -= 1;
    }

    public void Lost()
    {
        Debug.Log("LOST!!!!!!");

        //update player health
        GameManager.loseHealth(1);

        SceneManager.LoadScene("Overworld");
        //pause game
        //Time.timeScale = 0;
    }

    public void Won()
    {
        Debug.Log("WON!!!!!");

        //update score
        GameManager.addScore(100);

        SceneManager.LoadScene("Overworld");

        //pause game
        //Time.timeScale = 0;
    }
}
