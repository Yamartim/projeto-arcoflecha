using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float walkSpeed = 5;
    void Start()
    {
        
    }

    void Update()
    {
        // Andar para direita
        if(Input.GetKey(KeyCode.D)) {
            myRigidbody.velocity += Vector2.right * walkSpeed *Time.deltaTime;
            
        }
        
        // Andar para esquerda
        if(Input.GetKey(KeyCode.A)) {
            myRigidbody.velocity += Vector2.left * walkSpeed *Time.deltaTime;
            
        }


    }


}
