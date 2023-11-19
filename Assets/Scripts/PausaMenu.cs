using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaMenu : MonoBehaviour
{
    public static bool Pausa = false;
    public GameObject PausaMenuCanvas;
    private Arco arco;
    private Mira mira;

    void Start()
    {
        Time.timeScale = 1f;
        arco = FindObjectOfType<Arco>();
        mira = FindObjectOfType<Mira>();
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

        if (arco != null)
        {
            arco.SetCanShoot(false);
        }

        if (mira != null)
        {
            mira.SetActive(false);
        }
    }

    public void Jogar()
    {
        PausaMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Pausa = false;

        if (arco != null)
        {
            arco.SetCanShoot(true);
        }

        if (mira != null)
        {
            mira.SetActive(false); 
        }
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
 
}