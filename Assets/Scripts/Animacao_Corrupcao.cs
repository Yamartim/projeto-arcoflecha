using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacao_Corrupcao : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        int num = Random.Range(1,201);
        if(num == 100) {
            gameObject.transform.Rotate(0.0f, 0.0f, 90.0f);
        }
    }
}
