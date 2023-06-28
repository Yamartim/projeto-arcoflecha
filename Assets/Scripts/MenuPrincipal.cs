using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {
    public void sair (){
        Debug.Log("sair");
        Application.Quit();
    }

    //public void jogar (){
    //    SceneManagement.LoadScene(1);
    //}

}
