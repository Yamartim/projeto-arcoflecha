using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int vidaMaxima = 100; // Valor máximo de vida
    public int vidaAtual; // Valor atual de vida
    public bool[] flechasLiberadas = {false,false,false,false};
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
