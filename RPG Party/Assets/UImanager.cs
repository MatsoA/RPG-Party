using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject temp;
    public GameManagerS manager;

    public void Start()
    {
        temp = this.transform.parent.gameObject;
        manager = this.transform.parent.transform.parent.transform.parent.GetComponent<GameManagerS>();

    }
    public void resume()
    {
        
        manager.paused = false;
        temp.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
