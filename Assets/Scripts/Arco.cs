using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arco : MonoBehaviour
{
    public Transform  FirePoint;
    public GameObject FlechaPreFab;

    // Update is called once per frame
    void Update()
    {
        //calculo da direção da flecha;
        Vector2 posicaoArco = transform.position;
        Vector2 posicaoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direcao = posicaoMouse - posicaoArco;
        transform.right = direcao;

        if(Input.GetButtonDown("Fire1")){

            Shoot();
        }

        void Shoot(){
            //logica do tiro
            Instantiate(FlechaPreFab, FirePoint.position, FirePoint.rotation);
        }
    }
}
