using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentarFlechas : MonoBehaviour
{
    public float amp;
    public float freq;
   
    void Update()
    {
        transform.position += Vector3.up * amp * freq * Mathf.Cos(freq * Time.time) * Time.deltaTime; 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
            if(other.gameObject.CompareTag("Player")){
                other.gameObject.GetComponentInChildren<Arco>()?.AumentarFlechas();
                // other.gameObject.GetComponent<EfeitosSonoros>().playColetarFlecha();
                gameObject.GetComponent<AudioSource>().Play();
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                Destroy(gameObject, 4.0f);
            }
    }
    
}
