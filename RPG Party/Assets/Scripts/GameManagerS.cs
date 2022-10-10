using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerS : MonoBehaviour
{
    public static GameManagerS Instance;
    public int health = 2;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void loadScene()
    {
        SceneManager.LoadScene("BillScene");
    }

}