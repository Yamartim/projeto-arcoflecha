using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiarioManager : MonoBehaviour
{
    public static bool Diario = false;
    public GameObject DiarioManagerCanvas;

    void Start()
    {
        Time.timeScale = 1f;
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(Diario)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }

    void Stop()
    {
        DiarioManagerCanvas.SetActive(true);
        Time.timeScale = 0f;
        Diario = true;
    }

    public void Play()
    {
        DiarioManagerCanvas.SetActive(false);
        Time.timeScale = 1f;
        Diario = false;
    }
}
