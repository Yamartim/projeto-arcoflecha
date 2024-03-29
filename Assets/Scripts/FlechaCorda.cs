using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaCorda : Flecha
{
    [SerializeField] GameObject corda;
    bool cordaAtiva = false;

    GameObject instancia;
    [SerializeField] Transform cordaSpawn;

    private void OnCollisionEnter2D(Collision2D other) {
        // só solta uma corda se colidir com a coisa certa
            // por enquanto a coisa certa é qualquer coisa q n seja o jogador e outra corda
        if (!cordaAtiva && !other.gameObject.CompareTag("Player"))
        {
            EfeitoColisao();
            GetComponent<AudioSource>().Play();
            // congela a fisica da flecha
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            rb.isKinematic = false;
            coll.enabled = false;
            // faz a flecha grudar em plataformas móveis
            if(other.gameObject.CompareTag("Plataforma"))
                transform.parent = other.transform;
            // instancia a corda
            instancia = Instantiate(corda, cordaSpawn.position, transform.rotation, parent: transform);
            instancia.SetActive(true);
            cordaAtiva = true;
        }
    }

    // quando voltar pro jogador faz igual a flecha base + destroi a corda
    public override void RetornarPlayer(){
        Destroy(instancia);
        base.RetornarPlayer();
    }
}
