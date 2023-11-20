using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaGelo : Flecha
{
    [SerializeField] GameObject geloPreFab;

    private bool JaColidiu = false;
    
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Agua") && JaColidiu == false){   
            Vector2 position = other.gameObject.transform.position;
            Quaternion rotation = other.gameObject.transform.rotation;
            
            geloPreFab.transform.localScale = other.gameObject.transform.localScale;
            
            Destroy(other.gameObject);
            Instantiate(geloPreFab, position, rotation);

            Debug.Log("agua");

            JaColidiu = true;
        }
    }
}
