using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovPlatMovel : MonoBehaviour
{
    public float velocidade;    // velocidade da plataforma
    public int pontoInicial;    // posição inicial da plataforma
    public Transform[] pontos;  // posições que a plataforma toma
    private int i;
    void Start()
    {
        transform.position = pontos[pontoInicial].position;
    }
    void Update()
    {
        // se plataforma tiver muito perto do ponto onde tem que ir ...
        if(Vector2.Distance(transform.position, pontos[i].position) < 0.02f) {
            // passe para o próximo ou comece do 0
            i++;
            if(i == pontos.Length) {
                i = 0;
            }
        }
        // move a plataforma para o próximo ponto da array
        transform.position = Vector2.MoveTowards(transform.position, pontos[i].position, velocidade*Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col) {
        col.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D col) {
        col.transform.SetParent(null);
    }
}
