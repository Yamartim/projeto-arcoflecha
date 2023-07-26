using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public Vector3 startPosition;
    Status player;

    public int vidaMaxima = 100; // Valor máximo de vida
    public int vidaAtual; // Valor atual de vida

    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Status>();
       startPosition = transform.position;
       player.vidaAtual = player.vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        if ( player.vidaAtual <= 0)
        {
            ResetPosition();
        }
        
    }

    void ResetPosition()
    {
        // Redefina a posição para a posição inicial
        transform.position = startPosition;
    }

    public void PerderVida()
    {
        player.vidaAtual = player.vidaAtual - 10;
    }
    

    //salvar os status do player
     private void SavePlayerState(GameObject Player)
     {
        
        PlayerPrefs.SetFloat("PlayerPosX", Player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", Player.transform.position.y);
        //PlayerPrefs.SetFloat("PlayerPosZ", Player.transform.position.z);
        PlayerPrefs.Save();

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "espinho"){
            PerderVida();
        }

        if(collision.gameObject.tag == "CheckPoint"){
            SavePlayerState(collision.gameObject);
            startPosition = transform.position;
        }
    }

}
