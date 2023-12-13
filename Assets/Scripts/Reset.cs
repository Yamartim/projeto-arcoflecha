using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Reset : MonoBehaviour
{
    public Vector2 posRevive;
    Status player;

    public float taxaPerda, taxaGanho;

    private Movimento movim;
    private Arco arco;

    bool estaMorto = false;

    private SpriteRenderer rend;

    //public Color CorPadrao;

    public Color CorDano1;
    public Color CorDano2;
    public Color CorDano3;
    public Color CorDano4;

    GameObject ultimoCheckPoint = null;

    [SerializeField] float delayRevive = 1.5f;

    

    
    // Start is called before the first frame update.
    void Start()
    {
        player = GetComponent<Status>();
        posRevive = transform.position;
        player.vidaAtual = player.vidaMaxima;

        rend = GetComponent<SpriteRenderer>();
        rend.color = rend.color;

        movim = GetComponent<Movimento>();
        arco = GetComponentInChildren<Arco>();
    }

    // Update is called once per frame
    void Update()
    {
        // conferindo se o personagem morreu, caso sim, retornar a posição inicial.
//        if(player.vidaAtual > 0 && isDead == false){
//           
//        } 

        if ( player.vidaAtual <= 0 && !estaMorto)
        {
            estaMorto = true;
            StartCoroutine(SequenciaMorte());
            //Debug.Log(vidaAtual);
        }

        // se a vida não está cheia...
        if (player.vidaAtual<player.vidaMaxima && player.vidaAtual != player.vidaMaxima){
            // e Player está no chão, regenerar
            if(gameObject.GetComponent<Movimento>().grounded) {
                GanharVida();
            }
        }
        // para não ultrapassar a vida máxima
        if (player.vidaAtual>player.vidaMaxima){
            player.vidaAtual = player.vidaMaxima;
        }

        //variar a cor do personagem, conforme a vida atual dele, para indicar a situação da vida do personagem ao jogador.
        if(player.vidaAtual > 0.8*player.vidaMaxima){
            rend.color = Color.white;
        } else if(player.vidaAtual > 0.6*player.vidaMaxima) {
            rend.color = CorDano1;
        } else if(player.vidaAtual > 0.4*player.vidaMaxima){
            rend.color = CorDano2;
        } else if(player.vidaAtual > 0.2*player.vidaMaxima){
            rend.color = CorDano3;
        } else {
            rend.color = CorDano4;
        }
    }

    void ResetPosition()
    {
        // Redefina a posição para a posição inicial.
        transform.position = posRevive;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //rend.color = CorPadrao;
        rend.color = Color.white;
    }

    public void PerderVida()
    {
        player.vidaAtual -= taxaPerda * Time.deltaTime;
    }

    public void GanharVida(){
        player.vidaAtual += taxaGanho * Time.deltaTime;
    }

    

    //salvar os status do player.
    private void SavePlayerState(GameObject Player)
    {
        
        PlayerPrefs.SetFloat("PlayerPosX", Player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", Player.transform.position.y);
        PlayerPrefs.Save();

    }

    // caso o player colida com o checkpoint a posição inicial será redefinida para que renaça no checkpoint quando morrer.
    private void OnTriggerEnter2D(Collider2D collision) {
    
        if(collision.gameObject.tag == "CheckPoint"){
            SavePlayerState(collision.gameObject);
            posRevive = transform.position;

            collision.gameObject.GetComponent<AnimCheckpoint>().AtivarCP(true);
            if(ultimoCheckPoint != null && ultimoCheckPoint != collision.gameObject)
            {
                Debug.Log("entrou no if");
                ultimoCheckPoint.GetComponent<AnimCheckpoint>().AtivarCP(false);
            }
            ultimoCheckPoint = collision.gameObject;
            
        }
    }

    // enquanto estiver em contato com o objeto que dará dano, ele perde vida.
    private void OnTriggerStay2D(Collider2D collision) {

        if(collision.gameObject.tag == "Corrupcao"){
            PerderVida();
            Debug.Log("perdeu vida");
        }

        if(collision.gameObject.tag == "Agua"){
            taxaPerda = 35;
            PerderVida();
            Debug.Log("perdeu vida pela agua");
            taxaPerda = 110;
        }
        
    }

    
    IEnumerator SequenciaMorte()
    {
        Debug.Log("entrou na sequencia de morte");
        movim.EstadoMorte();


        arco.SetCanShoot(false);
        
        arco.Reload();

        yield return new WaitForSeconds(delayRevive);  // tempo para a animação rodar

        transform.position = posRevive;
        movim.EstadoReviver();
        arco.SetCanShoot(true);
        
        estaMorto=false;
        player.vidaAtual = player.vidaMaxima;
        rend.color = Color.white;
    }

}
