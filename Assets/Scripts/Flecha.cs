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
    //[SerializeField] GameObject prefabCorda;
    public float forca = 20f;
    public Rigidbody2D rb;
    public Collider2D coll;
    public Arco arcoref;
    public bool retornando;
    public tipoFlecha tipo;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        rb.AddForce(transform.right * forca);
    }

    private  void FixedUpdate() {
        // quando a flecha esta no modo "retorno" ela volta pro jogador, esse modo é ativado no arco
        if(retornando)
        {
            transform.position =  Vector2.MoveTowards(transform.position, arcoref.transform.parent.transform.position, 1f);
            //rb.AddForce(Vector2.MoveTowards(transform.position, arcoref.transform.position, 10f));
        }
    }


    //se a flecha tem uma corda da pra destruir a corda com esse metodo
    /*public void DesfazerFlecha()
    {
        if (tipo == tipoFlecha.Corda)
        {
            Destroy(prefabCorda);
        }
    }*/

    // desativa modo estatico da flecha apos a colisão e colocoa ela no modo de retorno pra voltar pro player
    public void RetornarPlayer(){
        //DesfazerFlecha();
        rb.constraints = RigidbodyConstraints2D.None;
        rb.isKinematic = false;
        rb.gravityScale = 0f;
        coll.enabled = true;
        coll.isTrigger = true;
        retornando = true;


    }


    // se a flecha ta no modo retorno e volta pro player ela se torna colecionavel e volta pro inventario
    private void OnTriggerEnter2D(Collider2D other) {
        if(retornando && other.CompareTag("Player"))
        {
            other.gameObject.GetComponentInChildren<Arco>().RecuperarFlecha(this);
            Destroy(gameObject);
            //da push numa pilha de flechas?
        }
    }



}
