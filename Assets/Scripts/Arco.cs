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
        if(Input.GetButtonDown("Fire1")){

            Shoot();
        }

        void Shoot(){
            //logica do tiro
            Instantiate(FlechaPreFab, FirePoint.position, FirePoint.rotation);
        }
    }
}
