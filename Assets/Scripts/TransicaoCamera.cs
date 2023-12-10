using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransicaoCamera : MonoBehaviour
{
    public GameObject virtualCam;

   private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger){
            virtualCam.SetActive(true);
            ScreenShake.shakeAtivo = this.GetComponentInChildren<ScreenShake>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger){
            virtualCam.SetActive(false);
        }
    }
}
