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
        hj = GetComponent<HingeJoint2D>();
        conectadoAcima = hj.connectedBody.gameObject;
        conectadoAbaixo = null;
        PosicionarSegmento();
    }

    void PosicionarSegmento()
    {
        SegmentoCorda segAcima = conectadoAcima.GetComponent<SegmentoCorda>();
        if(segAcima != null)
        {
            segAcima.conectadoAbaixo = this.gameObject;
            //float pontoConexao = conectadoAcima.GetComponent<SpriteRenderer>().bounds.size.y;
            float pontoConexao = 1f; //ta zuado de fazer a função dinamica então fica assim msm
            
            hj.connectedAnchor = new Vector2(0, pontoConexao*-1);
        } else {
            hj.connectedAnchor = Vector2.zero;
        }
    }

    public bool EhSegmentoInicial()
    {
        return conectadoAcima.GetComponent<SegmentoCorda>() == null;
    }

    public bool EhSegmentoFinal()
    {
        return conectadoAbaixo == null;
    }
}
