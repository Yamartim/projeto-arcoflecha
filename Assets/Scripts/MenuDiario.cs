using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDiario : MonoBehaviour
{
    public static bool Diario = false;
    public GameObject DiarioCanvas;

    void Comecar()
    {
        Time.timeScale = 1f;
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(Diario)
            {
                Voltar();
            }
            else
            {
                Parar();
            }
        }
    }

    void Parar()
    {
        DiarioCanvas.SetActive(true);
        Time.timeScale = 1f;
        Diario = true;
    }

    public void Voltar()
    {
        DiarioCanvas.SetActive(false);
        Time.timeScale = 1f;
        Diario = false;
    }
}
