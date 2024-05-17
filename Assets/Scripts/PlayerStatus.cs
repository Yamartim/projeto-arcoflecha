using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [Header("Vida")]
    public float vidaMaxima; // Valor máximo de vida
    public float vidaAtual; // Valor atual de vida
    [Space]

    [Header("Colecionaveis")]
    public int totalFlechas = 5;
    public int paginasColetadas = 0;
    //public bool[] paginasColetadas;
    public bool[] aneisLiberados;

    [Space]
    [SerializeField] MenuDiario uiDiario;
    [SerializeField] GameObject textoTrocaAnel;
    public static PlayerStatus instancia;



    void Awake()
    {
        if(instancia == null)
            instancia = this;

    }

    public void LiberarFlecha(tipoFlecha tipo){
        // switch(tipo)
        // {
        // case tipoFlecha.Gelo:
        //     Status.status.flechasLiberadas[1] = true;
        // break;
        // case tipoFlecha.Fogo:
        //     Status.status.flechasLiberadas[2] = true;
        // break;
        // case tipoFlecha.Luz:
        //     Status.status.flechasLiberadas[3] = true;
        // break;
        // }

        textoTrocaAnel.SetActive(true);
        aneisLiberados[(int)tipo] = true;
        Debug.Log("Flecha Liberada = "+((int)tipo)+"("+tipo+")");
    } 

    public void LiberarPagina()
    {
        paginasColetadas++;
        //paginasColetadas[index] = true;

        uiDiario.AtualizarPaginas(paginasColetadas);
    }

    public void AumentarTotalFlechas()
    {
        totalFlechas++;
    }

    public void ToggleMovMira(bool toggle)
    {
        GetComponent<PlayerMovimento>().ToggleMovimento(toggle);
        GetComponentInChildren<PlayerMira>().MiraAtiva(toggle);
    }

//logica apenas para debug no editor
#if UNITY_EDITOR
    void Update()
    {
        //botao pra liberar todas as flechas
        if(Input.GetKeyDown(KeyCode.F1))
        {
            for(int i=0; i<aneisLiberados.Length; i++)
            {
                aneisLiberados[i] = true;
            }
        }
    }
#endif
}
