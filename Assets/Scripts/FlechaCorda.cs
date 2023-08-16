using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaCorda : Flecha
{
    [SerializeField] GameObject corda;
    bool cordaAtiva = false;

    private void OnCollisionEnter2D(Collision2D other) {

        
        if (!cordaAtiva && !other.gameObject.CompareTag("Player"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Instantiate(corda, transform.position, transform.rotation, transform);
            rb.isKinematic = false;
            cordaAtiva = true;
        }
    }

    public new void RetornarPlayer(){
        base.RetornarPlayer();
        Destroy(corda);
    }
}
