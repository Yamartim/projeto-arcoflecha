using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D bc;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float acceleration;
    public int jumpPower;
    public float velMax;
    bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();

        // PhysicsMaterial2D mat = new PhysicsMaterial2D("Material");
        // mat.friction = 0;
        // bc.sharedMaterial = mat;
    }

    void Update()
    {
        // Andar para direita
        if(Input.GetKey(KeyCode.D) && rb.velocity.x < velMax) {
            rb.velocity += Vector2.right * acceleration * Time.deltaTime;
        }
        
        // Andar para esquerda
        if(Input.GetKey(KeyCode.A) && rb.velocity.x > -velMax) {
            rb.velocity += Vector2.left * acceleration * Time.deltaTime;
        }

        // Pulo
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, 
            new Vector2(1.8f, 0.3f), CapsuleDirection2D.Horizontal, 
            0, groundLayer);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }
}
