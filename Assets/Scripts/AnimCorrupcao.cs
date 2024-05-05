using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacao_Corrupcao : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        // dar 1 chance em 100 de rotacionar num frame
        int numAleatorio = Random.Range(0, 100);
        if(numAleatorio == 50 && gameObject.GetComponent<Renderer>().isVisible) {
            // apenas rotaciona se estiver visível
            gameObject.transform.Rotate(0.0f, 0.0f, 90.0f);
        }
    }
}
