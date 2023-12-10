using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Status : MonoBehaviour
{
    public float vidaMaxima; // Valor máximo de vida
    public float vidaAtual; // Valor atual de vida
    public bool[] flechasLiberadas;
    public static Status instancia;


    // Start is called before the first frame update
    void Start()
    {
        if(instancia == null)
            instancia = this;

    }

    
}
