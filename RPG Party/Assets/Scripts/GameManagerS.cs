using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerS : MonoBehaviour
{
    public static GameManagerS Instance;
    public int health = 2;
    public int score = 0;
    public Transform canvas;
    public TMPro.TextMeshProUGUI textMeshPro;
    public TMPro.TextMeshProUGUI textMeshProhealth;
    public GameObject pause;
    public bool paused = false;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        canvas = this.transform.GetChild(0);
        textMeshPro = canvas.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
        textMeshProhealth = canvas.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>();
        pause = canvas.transform.GetChild(2).gameObject;
        Time.timeScale = 1;
    }

    public void Update()
    {
        textMeshPro.text = "Score: " + score.ToString();
        textMeshProhealth.text = "Health: " + health.ToString();
        if (Input.GetKey(KeyCode.P))
        {
            Time.timeScale = 0;
            pause.SetActive(true);
            paused = true;


        }
 

    }

    public void loadScene()
    {
        SceneManager.LoadScene("BillScene");
    }

    public void overworltominigame()
    {
        SceneManager.LoadScene(Random.Range(2,5));
    }

    public void loseHealth(int damage)
    {
        health -= damage;
    }

    public void addScore(int addition)
    {
        score += addition;
    }
}
