using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaFogo : Flecha
{
        [SerializeField] GameObject aguaPreFab;

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Madeira")){   
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Gelo")){   
            Vector2 position = other.gameObject.transform.position;
            Quaternion rotation = other.gameObject.transform.rotation;
            
            aguaPreFab.transform.localScale = other.gameObject.transform.localScale;
            
            Destroy(other.gameObject);
            Instantiate(aguaPreFab, position, rotation);
        }
    }
}

