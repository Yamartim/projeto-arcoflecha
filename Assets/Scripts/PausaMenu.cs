using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaMenu : MonoBehaviour
{
    public static bool Pausa = false;
    public GameObject PausaMenuCanvas;

    void Start()
    {
        Time.timeScale = 1f;
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Pausa)
            {
                Jogar();
            }
            else
            {
                Parar();
            }
        }
    }

    void Parar()
    {
        PausaMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        Pausa = true;
    }

    public void Jogar()
    {
        PausaMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Pausa = false;
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
        
}
