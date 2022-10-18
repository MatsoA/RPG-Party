using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    public GameManagerS GameManager;

    private void Start()
    {
        GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManagerS>();
    }

    // Update is called once per frame
    public void scenemovement()
    {
        GameManager.overworltominigame();
    }
}
