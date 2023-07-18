using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentoCorda : MonoBehaviour
{

    GameObject conectadoAcima, conectadoAbaixo;
    HingeJoint2D hj;


    // Start is called before the first frame update
    void Start()
    {
        hj = GetComponent<HingeJoint2D>();
        conectadoAcima = hj.connectedBody.gameObject;
        PosicionarSegmento();
    }

    void PosicionarSegmento()
    {
        SegmentoCorda segAcima = conectadoAcima.GetComponent<SegmentoCorda>();
        if(segAcima != null)
        {
            segAcima.conectadoAbaixo = this.gameObject;
            float pontoConexao = conectadoAcima.GetComponent<SpriteRenderer>().bounds.size.y;
            
            hj.connectedAnchor = new Vector2(0, pontoConexao*-1);
        } else {
            hj.connectedAnchor = Vector2.zero;
        }
    }
}
