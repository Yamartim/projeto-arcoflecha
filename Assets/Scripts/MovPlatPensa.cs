using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovPlatPensa : MonoBehaviour
{
    private float yPos;
    private Boolean playerEncima;
    public float tolerancia;
    void Start()
    {
        playerEncima = false;
    }

    // Update is called once per frame
    void Update()
    {
        yPos = gameObject.transform.position.y;
        Debug.Log(playerEncima);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player") && other.gameObject.transform.position.y > yPos + tolerancia) {
            playerEncima = true;
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) {
            playerEncima = false;
        }
    }
}
