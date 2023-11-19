using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaLuz : Flecha
{
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Corrupcao")){   
            Destroy(other.gameObject);
        }
    }
}

