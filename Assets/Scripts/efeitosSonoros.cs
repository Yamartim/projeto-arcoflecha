using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class efeitosSonoros : MonoBehaviour
{
    public AudioSource src;
    public AudioClip atirarFlecha, coletarFlecha, coletarAnel;
    public void playAtirarFlecha()
    {
        src.PlayOneShot(atirarFlecha);
    }

    public void playColetarFlecha()
    {
        src.PlayOneShot(coletarFlecha);
    }

}
