using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaGelo : Flecha
{
    [SerializeField] GameObject geloPreFab;
    
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Agua")){   
            Vector2 position = other.gameObject.transform.position;
            Quaternion rotation = other.gameObject.transform.rotation;
            
            geloPreFab.transform.localScale = other.gameObject.transform.localScale;
            
            Destroy(other.gameObject);
            Instantiate(geloPreFab, position, rotation);
        }
    }
}
