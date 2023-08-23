using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaFogo : Flecha
{
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Madeira")){   
            Destroy(other.gameObject);
        }
    }
}

