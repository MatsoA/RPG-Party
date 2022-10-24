using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI time;
    public float timeLeft;
    
    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        time.text = timeLeft.ToString("0");
        if(timeLeft <= 0)
        {
            timeLeft = 0;
        }
    }
    public float GetTime()
    {
        return timeLeft;
    }
}
