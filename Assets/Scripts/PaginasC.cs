using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaginasC : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            // Acessa diretamente a instância estática do Diario usando FindObjectOfType
            Diario diario = FindObjectOfType<Diario>();
            
            if (diario != null)
            {
                diario.ColetarPagina();
                Debug.Log("ColetarPagina chamada");
            }

            gameObject.SetActive(false);
        }
    }
}