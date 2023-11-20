using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FlechaFogo : Flecha
{
        [SerializeField] GameObject aguaPreFab;

        private bool JaColidiu = false;

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Madeira") && JaColidiu == false){   
            Destroy(other.gameObject);
            JaColidiu = true;
        }

        if(other.gameObject.CompareTag("Gelo") && JaColidiu == false){   
            Vector2 position = other.gameObject.transform.position;
            Quaternion rotation = other.gameObject.transform.rotation;
            
            aguaPreFab.transform.localScale = other.gameObject.transform.localScale;
            
            Destroy(other.gameObject);
            Instantiate(aguaPreFab, position, rotation);

            JaColidiu = true;
        }
        if(!other.gameObject.CompareTag("Player")){
            rb.velocity = Vector2.zero;
        }
    }
}

