using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public float vidaMaxima; // Valor máximo de vida
    public float vidaAtual; // Valor atual de vida
    public bool[] flechasLiberadas;
    public static Status status;
    
    

    // Start is called before the first frame update
    void Start()
    {
       if(status == null)
            status = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
