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
            other.gameObject.GetComponentInChildren<Arco>().addTipoFlecha(tipo);
            other.gameObject.GetComponent<EfeitosSonoros>().playColetarAnel();
            Destroy(gameObject);
        }
    }   
}
