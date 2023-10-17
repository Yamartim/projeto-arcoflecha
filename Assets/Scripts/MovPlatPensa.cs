using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovPlatPensa : MonoBehaviour
{
    private float yPos, yAlto, yBaixo, t, timeStamp;
    private Boolean playerEncima;
    public float tolerancia, dist, k;
    void Start()
    {
        playerEncima = false;
        yAlto = gameObject.transform.position.y + dist/2;
        yBaixo = yAlto - dist;
        timeStamp = 0;
    }

    void Update()
    {
        t = Time.time - timeStamp;
        yPos = gameObject.transform.position.y;
        if(t < 5/k) {   // se não passou muito tempo...
            if(playerEncima) {
                // descer a plataforma
                transform.position += Vector3.up * (yBaixo - yPos)*k*Mathf.Exp(-k*t)*Time.deltaTime;
            } else {
                // subir a plataforma
                transform.position += Vector3.up * (yAlto - yPos)*k*Mathf.Exp(-k*t)*Time.deltaTime;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player") && other.gameObject.transform.position.y > yPos + tolerancia) {
            playerEncima = true;
            timeStamp = Time.time;
        }
    }

    void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player") && other.gameObject.transform.position.y > yPos + tolerancia) {
            playerEncima = true;
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) {
            playerEncima = false;
            timeStamp = Time.time;
        }
    }
}
