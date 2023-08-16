using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaCorda : Flecha
{
    [SerializeField] GameObject corda;
    bool cordaAtiva = false;

    private void OnCollisionEnter2D(Collision2D other) {
        // só solta uma corda se colidir com a coisa certa
            // por enquanto a coisa certa é qualquer coisa q n seja o jogador
        if (!cordaAtiva && !other.gameObject.CompareTag("Player"))
        {
            // congela a fisica da flecha e instancia a corda
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            rb.isKinematic = false;
            Instantiate(corda, transform.position, transform.rotation, transform);
            cordaAtiva = true;
        }
    }

    // quando voltar pro jogador faz igual a flecha base + destroi a corda
    public new void RetornarPlayer(){
        Destroy(corda);
        base.RetornarPlayer();
    }
}