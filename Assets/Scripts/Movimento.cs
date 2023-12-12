using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    Rigidbody2D rb;
    CapsuleCollider2D col;
    PhysicsMaterial2D mat;
    AnimacaoPlayer anim;
    public Transform groundCheck, tetoCheck;
    public LayerMask groundLayer;
    bool movimentoPerimitido;
    public float aceleracao;
    public int forcaPulo;
    public float velMax;
    public float inputHorizontal, inputVertical;
    bool cordaProxima, escalando, tetoEncima;
    public bool grounded;
    public float velEscalada = 1f;    
    HingeJoint2D hj;
    // Rigidbody2D cordaProxRB;
    public List<Rigidbody2D> cordasProxRB = new();
    GameObject cordaAtual = null;

    void Start()
    {
        movimentoPerimitido = true;

        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        hj = GetComponent<HingeJoint2D>();
        anim = GetComponent<AnimacaoPlayer>();

        mat = new PhysicsMaterial2D("Material");
        mat.friction = 1f;
        col.sharedMaterial = mat;
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        grounded = IsGrounded();

        if (movimentoPerimitido)
        {

            // Andar
            InputAndar();

            // Pular
            InputPulo();

            InputEscalada();

        }

    }

#region logica de andar
    private void InputAndar()
    {
        bool podeAndarDir = inputHorizontal == 1 && rb.velocity.x < velMax;
        bool podeAndarEsq = inputHorizontal == -1 && rb.velocity.x > -velMax;
        bool podeAndar = podeAndarDir || podeAndarEsq;
        if (inputHorizontal != 0 && podeAndar)
        {
            rb.velocity += Vector2.right * inputHorizontal * aceleracao * Time.deltaTime;
            mat.friction = 0f;
            col.sharedMaterial = mat;
        }
        else if (inputHorizontal == 0)
        {
            // Se não estiver andando, adicionar atrito
            mat.friction = 1f;
            col.sharedMaterial = mat;
        }
    }
#endregion

#region logica de pular
    private void InputPulo()
    {
        if (Input.GetButtonDown("Jump") && (grounded || escalando))
        {
            rb.velocity = new Vector2(rb.velocity.x, forcaPulo);
            SoltarCorda();
            anim.AnimPular();
        }
    }
#endregion

    
#region logica de escalar
    void InputEscalada()
    {
        if(cordasProxRB.Count == 0) {
            cordaProxima = false;
        } else {
            cordaProxima = true;
        }
        // Debug.Log(cordasProxRB.Count);
        // se ta perto de uma corda e o player aperta pra cima ou pra beixo agarra
        if(cordaProxima && (inputVertical > 0) && !escalando)
        {   
            // ordena lista de segmentos próximos da maior posição y para a menor
            if(cordasProxRB.Count > 1) {
                cordasProxRB.Sort((i, j) => j.transform.position.y.CompareTo(i.transform.position.y));
            }
            // agarra no segmento mais alto
            AgarrarCorda(cordasProxRB[0]);
        }

        // logica da escalada
        if(escalando)
        {
            //referencia de qual ponta da corda nos estamos agarrando
            SegmentoCorda seg = hj.connectedBody.GetComponent<SegmentoCorda>();
            rb.gravityScale = 0f;

            //rb.velocity = new Vector2(rb.velocity.x, inputVertical * velMax);

            tetoEncima = TemTeto();
            
            // se o teto não estiver impedindo o movimento ...
            if((inputVertical < 1) || ((inputVertical == 1) && !tetoEncima)) {
                // ao inves de se mover com fisica, vamos alterar nossa posição relativa a corda
                hj.connectedAnchor += Vector2.up * inputVertical * Time.deltaTime *velEscalada;
            }

            // se tocarmos no chão enquanto escalamos...
            if(grounded && (inputVertical <= 0)) {
                SoltarCorda();
            }

            // se chegamos no fim de um segmento de cords subindo...
            if (hj.connectedAnchor.y > 0f)
            {
                // se n tiver mais corda em cima soltamos
                if (seg.EhSegmentoInicial()){
                    hj.connectedAnchor = Vector2.zero;
                }
                else { // senao conectamos no proximo segmento posicionando relativamente
                    //Debug.Log("sobe um segmento...");
                    hj.connectedAnchor = new Vector2(0, (hj.connectedAnchor.y-1) % -1);
                    hj.connectedBody = seg.conectadoAcima.gameObject.GetComponent<Rigidbody2D>();
                }
            }

            // se chegamos no fim de um segmento de cords descendo...
            if (hj.connectedAnchor.y < -1f){
                // se n tiver mais corda embaixo soltamos
                if (seg.EhSegmentoFinal() || grounded){
                    SoltarCorda();
                } else { // senao conectamos no proximo segmento posicionando relativamente
                    //Debug.Log("desce um segmento...");
                    hj.connectedAnchor = new Vector2(0, hj.connectedAnchor.y % -1);
                    hj.connectedBody = seg.conectadoAbaixo.GetComponent<Rigidbody2D>();
                }
            }
            
        }else{ // se n estamos escalando fisica fica normal
            rb.gravityScale = 3f;
            if (grounded)
            {
                // TESTE se sob hipotese alguma vc ta próximo de uma corda a lista tem q estar vazia
                cordasProxRB.Clear();
            }

        }
    }
#endregion

#region logica da corda
    // ativa o bool escalando e td q é necessario pro componente hingejoint
    void AgarrarCorda(Rigidbody2D corda)
    {
        // confere se ja nao estamos escalando ou tentando subir a msm corda
        bool acimaPlayer = gameObject.transform.position.y < corda.transform.position.y;
        if (corda.transform.parent != cordaAtual && acimaPlayer)
        {
            escalando = true;
            hj.enabled = true;
            hj.connectedBody = corda;
            cordaAtual = corda.transform.parent.gameObject;
            //Debug.Log("Segurei corda! " + hj.connectedAnchor);
        }
            
        anim.AnimSegCorda(true);
    }

    // desativa tudo pra fisica voltar a atuar no player
    void SoltarCorda()
    {
        //Debug.Log("Soltei corda! " + hj.connectedAnchor);
        escalando = false;
        hj.enabled = false;
        hj.connectedBody = null;
        cordaAtual = null;

        anim.AnimSegCorda(false);
    }
#endregion

#region funções de ground e teto
    bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position,
                    new Vector2(0, 0.3f), CapsuleDirection2D.Horizontal,
                    0, groundLayer); //tirar a groundlayer pra nao precisar ficar se preocupando com considerar tudo ground? -martim
    }

    bool TemTeto()
    {
        return Physics2D.OverlapCapsule(tetoCheck.position,
                    new Vector2(0, 0.3f), CapsuleDirection2D.Horizontal,
                    0, groundLayer);
    }
#endregion

#region  processando triggers de fisica
    // detectando se chegamos perto ou longe de uma corda
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("corda") && !cordaProxima)
        {
            // cordaProxima = true;
            // cordaProxRB = other.gameObject.GetComponent<Rigidbody2D>();
            Rigidbody2D segmento = other.gameObject.GetComponentInParent<Rigidbody2D>();
            if(!cordasProxRB.Contains(segmento)) {
                cordasProxRB.Add(segmento);
            }
        }

        if(other.CompareTag("Agua"))
        {
            rb.drag = 15;
        }
        

    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.CompareTag("corda"))
        {
            // cordaProxima = true;
            // cordaProxRB = other.gameObject.GetComponent<Rigidbody2D>();
            Rigidbody2D segmento = other.gameObject.GetComponentInParent<Rigidbody2D>();
            if(!cordasProxRB.Contains(segmento)) {
                cordasProxRB.Add(segmento);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("corda"))
        {
            // cordaProxRB = null;
            cordasProxRB.Remove(other.gameObject.GetComponentInParent<Rigidbody2D>());
        }
        
        if (other.CompareTag("Agua")){
            rb.drag = 1.2f;
        }
    }
#endregion

#region restrições no script
    public void ToggleMovimento(bool ativo)
    {
        movimentoPerimitido = ativo;
        gameObject.GetComponentInChildren<Arco>().SetCanShoot(ativo);
        anim.PausarAnim();
    }
#endregion

#region morte e reviver
    public void EstadoMorte()
    {
        ToggleMovimento(false);
        SoltarCorda();
        anim.ContinuarAnim();
        anim.AnimMorrer();
    }

    public void EstadoReviver()
    {
        rb.velocity = Vector2.zero;
        anim.ResetAnim();
        ToggleMovimento(true);
    }
#endregion

}
