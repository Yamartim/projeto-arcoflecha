using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacao_Corrupcao : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        // rotaciona um bloco de corrupção aleatoriamente por frame
        int indGrupo = Random.Range(0, gameObject.transform.childCount);
        Transform grupo = gameObject.transform.GetChild(indGrupo);
        int indAleatorio = Random.Range(0, grupo.transform.childCount);
        Transform blocoAleatorio = grupo.transform.GetChild(indAleatorio);
        blocoAleatorio.transform.Rotate(0.0f, 0.0f, 90.0f);
    }
}
