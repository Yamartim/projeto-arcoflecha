using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    private Vector3 startPosition;
    public int vidaMaxima = 100; // Valor máximo de vida
    public int vidaAtual; // Valor atual de vida
    
    // Start is called before the first frame update
    void Start()
    {
       startPosition = transform.position;
       vidaAtual = vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        if ( vidaAtual <= 0)
        {
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        // Redefina a posição para a posição inicial
        transform.position = startPosition;
    }

    public void PerderVida()
    {
        vidaAtual = vidaAtual - 20;
        Debug.Log("perdeu vida");
    }

    
}
