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
            other.gameObject.GetComponentInChildren<Arco>().AumentarFlechas();
            other.gameObject.GetComponent<efeitosSonoros>().playColetarFlecha();
            Destroy(gameObject);
        }
   }   
}
