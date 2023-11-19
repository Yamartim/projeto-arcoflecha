using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCheckpoint : MonoBehaviour
{

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void AtivarCP(bool state)
    {
        //Debug.Log("checkpoint" + state);
        anim.SetBool("ATIVADO", state);
    }

}
