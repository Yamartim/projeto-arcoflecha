using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitosSonoros : MonoBehaviour
{
    public AudioSource src;
    public AudioClip atirarFlecha, coletarFlecha, coletarAnel;
    public void playAtirarFlecha()
    {
        src.PlayOneShot(atirarFlecha);
    }

}
