using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anel : MonoBehaviour
{
    public float amp;
    public float freq;
    public tipoFlecha tipo;
   
    void Update()
    {
        transform.position += Vector3.up * amp * freq * Mathf.Cos(freq * Time.time) * Time.deltaTime; 
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            // other.gameObject.GetComponentInChildren<Arco>().addTipoFlecha(tipo);
            LiberarFlecha(tipo);
            //other.gameObject.GetComponent<EfeitosSonoros>().playColetarAnel();
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 4.0f);
        }
    }

    private void LiberarFlecha(tipoFlecha tipo){
        // switch(tipo)
        // {
        // case tipoFlecha.Gelo:
        //     Status.status.flechasLiberadas[1] = true;
        // break;
        // case tipoFlecha.Fogo:
        //     Status.status.flechasLiberadas[2] = true;
        // break;
        // case tipoFlecha.Luz:
        //     Status.status.flechasLiberadas[3] = true;
        // break;
        // }

        Status.instancia.flechasLiberadas[(int)tipo] = true;
        Debug.Log("Flecha Liberada = "+((int)tipo)+"("+tipo+")");
    } 
}
