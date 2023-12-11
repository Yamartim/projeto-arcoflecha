using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaMenu : MonoBehaviour
{
    public static bool jogoPausado = false;
    public GameObject PausaMenuCanvas;
    private Arco arco;
    private Mira mira;

    void Start()
    {
        Time.timeScale = 1f;
        arco = Status.instancia.GetComponent<Arco>();
        mira = FindObjectOfType<Mira>();
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(jogoPausado)
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
        jogoPausado = true;

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
        jogoPausado = false;

        if (arco != null)
        {
            arco.SetCanShoot(true);
        }

        if (mira != null)
        {
            mira.SetActive(true); 
        }
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
 
}