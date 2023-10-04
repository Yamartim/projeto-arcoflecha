using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public Vector2 startPosition;
    Status player;

    public int vidaMaxima; // Valor máximo de vida
    public int vidaAtual; // Valor atual de vida

    private Movimento Movimento;

    bool isDead = false;

    private SpriteRenderer rend;

    //public Color CorPadrao;

    //public Color CorDano1;

    //public Color CorDano2;


    

    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Status>();
       startPosition = transform.position;
       player.vidaAtual = player.vidaMaxima;

       rend = GetComponent<SpriteRenderer>();
       rend.color = rend.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.vidaAtual > 0 && isDead == false){
            
        }

        if ( player.vidaAtual <= 0 && !isDead)
        {
            isDead = true;
            ResetPosition();
            isDead=false;
            player.vidaAtual = player.vidaMaxima;
            //Debug.Log(vidaAtual);
        }
        
    }

    void ResetPosition()
    {
        // Redefina a posição para a posição inicial
        transform.position = startPosition;
        //rend.color = CorPadrao;
        rend.color = Color.white;
    }

    public void PerderVida()
    {
        player.vidaAtual = (player.vidaAtual - 1);

        if(player.vidaAtual <= 110) {
            //rend.color = CorDano1;
            rend.color = Color.red;
        }

       // if(player.vidaAtual <= 60) {
       //     //rend.color = CorDano1;
       //     rend.color = Color.red;
       // }        
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
    
        if(collision.gameObject.tag == "CheckPoint"){
            SavePlayerState(collision.gameObject);
            startPosition = transform.position;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {

        if(collision.gameObject.tag == "espinho"){
            
            PerderVida();
            //Debug.Log("perdeu 15 de vida");
        }

        
    }

}
