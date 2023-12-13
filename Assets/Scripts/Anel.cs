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
        // Movimenta para cima e para baixo
        transform.position += Vector3.up * amp * freq * Mathf.Cos(freq * Time.time) * Time.deltaTime; 
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            // Desativa todos os componentes e espera o efeito sonoro tocar para destruir objeto
            Status.instancia.LiberarFlecha(tipo);
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<ParticleSystem>().Stop();
            Destroy(gameObject, 4.0f);
        }
    }


}
