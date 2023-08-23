using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using Unity.VisualScripting;

public class AnimacaoPlayer : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("velocidade", Mathf.Abs(gameObject.GetComponent<Movimento>().inputHorizontal));
        
    }
}
