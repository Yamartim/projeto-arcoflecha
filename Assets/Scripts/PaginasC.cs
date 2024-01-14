using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaginasC : MonoBehaviour
{
    public Diario diario;

    void Start()
    {
        diario = FindObjectOfType<Diario>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            if (collider != null)
            {
                collider.enabled = false;
            }

            Debug.Log("Objeto Coletado");

            if (diario != null)
            {
                diario.ColetarPagina();
                Debug.Log("ColetarPagina chamada");
            }

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 1.0f);
            // gameObject.SetActive(false);
        }
    }
}

