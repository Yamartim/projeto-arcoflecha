using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaginasC : MonoBehaviour
{
    private bool coletado = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !coletado)
        {
            coletado = true;

            Diario diario = other.GetComponent<Diario>();
            if (diario != null)
            {
                diario.ColetarPagina();
            }

            gameObject.SetActive(false);
        }
    }
}