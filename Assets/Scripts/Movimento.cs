using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    Rigidbody2D rb;
    CapsuleCollider2D col;
    PhysicsMaterial2D mat;
    // public AudioSource src;
    // public AudioClip pular;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float aceleracao;
    public int forcaPulo;
    public float velMax;
    bool isGrounded;


    float inputHorizontal, inputVertical;

    bool cordaProxima, escalando;
    public float velEscalada = 20;
    
    //HingeJoint2D hj;
    //Rigidbody2D cordaProxRB;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        //hj = GetComponent<HingeJoint2D>();

        mat = new PhysicsMaterial2D("Material");
        mat.friction = 0.4f;
        col.sharedMaterial = mat;
    }

    void Update()
    {

        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        // Andar

        bool podeAndarDir = inputHorizontal == 1 && rb.velocity.x < velMax;
        bool podeAndarEsq = inputHorizontal == -1 && rb.velocity.x > -velMax;
        bool podeAndar = podeAndarDir || podeAndarEsq;
        if(inputHorizontal != 0 && podeAndar) {
            rb.velocity += Vector2.right * inputHorizontal * aceleracao * Time.deltaTime;
            mat.friction = 0f;
            col.sharedMaterial = mat;
        } else if(inputHorizontal == 0) {
            // Se não estiver andando, adicionar atrito
            mat.friction = 0.4f;
            col.sharedMaterial = mat;
        }
        
        // Pular
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, 
            new Vector2(0, 0.3f), CapsuleDirection2D.Horizontal, 
            0, groundLayer);
        if(Input.GetButtonDown("Jump") && (isGrounded || escalando)) {
            rb.velocity = new Vector2(rb.velocity.x, forcaPulo);
            escalando = false;
        }

        InputEscalada();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("corda"))
        {
            cordaProxima = true;
            //cordaProxRB = other.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.CompareTag("corda"))
        {
            cordaProxima = true;
            //cordaProxRB = other.gameObject.GetComponent<Rigidbody2D>();
        }
    }


    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("corda"))
        {
            cordaProxima = false;
            escalando = false;
            //cordaProxRB = null;
        }
    }

    void InputEscalada()
    {

        if(cordaProxima && (Mathf.Abs(inputVertical) > 0))
        {
            escalando = true;
            //hj.enabled = true;
            //hj.connectedBody = cordaProxRB;
        }

        if(escalando)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * velMax);
            
            mat.friction = 0.4f;
            col.sharedMaterial = mat;

        }else{
            rb.gravityScale = 3f;
            //hj.enabled = false;

        }
    }
}
