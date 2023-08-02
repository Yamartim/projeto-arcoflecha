using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anel : MonoBehaviour
{
    public float amp;
    public float freq;
<<<<<<< Updated upstream
    public string tipo;
=======
    public tipoFlecha tipo;
    public AudioClip coletarAnel;
>>>>>>> Stashed changes
   
    void Update()
    {
        // Animação movimento
        transform.position += Vector3.up * amp * freq * Mathf.Cos(freq * Time.time) * Time.deltaTime; 
    }

    void OnTriggerEnter2D(Collider2D other) {
<<<<<<< Updated upstream
       if(other.gameObject.CompareTag("Player")){
        other.gameObject.GetComponentInChildren<Arco>().addTipoFlecha(tipo);
        Destroy(gameObject);
       }
=======
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponentInChildren<Arco>().addTipoFlecha(tipo);
            //other.gameObject.GetComponent<EfeitosSonoros>().playColetarAnel();
            //gameObject.GetComponent<AudioSource>().PlayOneShot(coletarAnel);
            Debug.Log("Executou");
            Destroy(gameObject);
        }
>>>>>>> Stashed changes
    }   
}
