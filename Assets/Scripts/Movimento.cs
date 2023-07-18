using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D bc;
    PhysicsMaterial2D mat;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float acceleration;
    public int jumpPower;
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
        bc = GetComponent<BoxCollider2D>();
        //hj = GetComponent<HingeJoint2D>();

        mat = new PhysicsMaterial2D("Material");
        mat.friction = 0.4f;
        bc.sharedMaterial = mat;
    }

    void Update()
    {

        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        // Andar
        if(Mathf.Abs(inputHorizontal) > 0 && Mathf.Abs(rb.velocity.x) < velMax) {
            rb.velocity += Vector2.right * inputHorizontal * acceleration * Time.deltaTime;
            mat.friction = 0f;
            bc.sharedMaterial = mat;
        } 

        // Pular
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, 
            new Vector2(1.8f, 0.3f), CapsuleDirection2D.Horizontal, 
            0, groundLayer);
        if(Input.GetButtonDown("Jump") && (isGrounded || escalando)) {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            escalando = false;
        }

        // Se não estiver andando, adicionar atrito
        if(Mathf.Abs(inputHorizontal) == 0) {
            mat.friction = 0.4f;
            bc.sharedMaterial = mat;
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
            bc.sharedMaterial = mat;

        }else{
            rb.gravityScale = 3f;
            //hj.enabled = false;

        }
    }


}
