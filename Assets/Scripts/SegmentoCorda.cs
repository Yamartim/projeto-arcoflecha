using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentoCorda : MonoBehaviour
{
    public GameObject conectadoAcima, conectadoAbaixo;
    HingeJoint2D hj;


    // Start is called before the first frame update
    void Start()
    {
        // quando é criado pega a referencia do que ta conectado a ele e se posiciona em baixo
        hj = GetComponent<HingeJoint2D>();
        conectadoAcima = hj.connectedBody.gameObject;
        conectadoAbaixo = null;
        PosicionarSegmento();
    }

    void PosicionarSegmento()
    {
        SegmentoCorda segAcima = conectadoAcima.GetComponent<SegmentoCorda>();
        // se não é o topo fala pro de cima que esse está embaixo e se posiciona diretamente abaixo dele
        if(segAcima != null)
        {
            segAcima.conectadoAbaixo = this.gameObject;
            //float pontoConexao = conectadoAcima.GetComponent<SpriteRenderer>().bounds.size.y;
            float pontoConexao = 1f; //ta zuado de fazer a função dinamica então fica assim msm
            
            hj.connectedAnchor = new Vector2(0, pontoConexao*-1);
        } else {
            hj.connectedAnchor = Vector2.zero; // se é o topo a posição é zerada
        }
    }

    //metodos pro player saber qnd ta escalando se esse é o começo ou fim da corda
    public bool EhSegmentoInicial()
    {
        return conectadoAcima.GetComponent<SegmentoCorda>() == null;
    }

    public bool EhSegmentoFinal()
    {
        return conectadoAbaixo == null;
    }
}
