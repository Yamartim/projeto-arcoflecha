using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaLuz : Flecha
{
    private void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.CompareTag("Corrupcao")){   
            Destroy(other.gameObject);
        }
    }
}

