using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum tipoFlecha {
    Corda,
    Fogo,
    Gelo,
    Luz
}

public class Flecha : MonoBehaviour
{
    [SerializeField] GameObject prefabCorda;
    public tipoFlecha tipo;
    public float forca = 20f;
    public Rigidbody2D rb;
    public Collider2D coll;
    public Arco arcoref;
    public bool retornando;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.right * forca);

    }

    private void Update() 
    {
        // quando a flecha esta no modo "retorno" ela volta pro jogador, esse modo é ativado no arco
        if(retornando)
        {
            rb.AddForce(Vector2.MoveTowards(transform.position, arcoref.transform.position, 10f));
        }
    }

    // quando a flecha bate e algo algo acontece dependendo do tipo
    private void OnCollisionEnter2D(Collision2D other) {
        switch (tipo)
        {
            case tipoFlecha.Corda:
                rb.isKinematic = true;
                coll.enabled = true;
                Instantiate(prefabCorda);
                break;
                
            case tipoFlecha.Fogo:
                if(other.gameObject.CompareTag("madeira"))
                {
                    //get component script madeira
                    //madeira.queima
                }
                break;
            case tipoFlecha.Gelo:
                if(other.gameObject.CompareTag("agua"))
                {
                    //get component script agua
                    //agua.congela
                }
                break;
            case tipoFlecha.Luz:
                if(other.gameObject.CompareTag("corrupcao"))
                {
                    //get component script corrup
                    //corrup.destroi
                }
                break;
            default:
                break;
        }
    }


    //se a flecha tem uma corda da pra destruir a corda com esse metodo
    public void DesfazerFlecha()
    {
        if (tipo == tipoFlecha.Corda)
        {
            Destroy(prefabCorda);
        }
    }

    // desativa modo estatico da flecha apos a colisão e colocoa ela no modo de retorno pra voltar pro player
    public void RetornarPlayer(){
        DesfazerFlecha();
        rb.isKinematic = false;
        rb.gravityScale = 0f;
        coll.isTrigger = true;
        retornando = true;

    }

    // se a flecha ta no modo retorno e volta pro player ela se torna colecionavel e volta pro inventario
    private void OnTriggerEnter2D(Collider2D other) {
        if(retornando && other.CompareTag("Player"))
        {
            other.gameObject.GetComponentInChildren<Arco>().RecuperarFlecha();
            Destroy(gameObject);
            //da push numa pilha de flechas?
        }
    }

}
