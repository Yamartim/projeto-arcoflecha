using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Arco : MonoBehaviour
{
    //esse total de flechas dps tem q ir pra classe de stats do jogador
    public int TotalFlecha = 5;

    public Collider2D playercoll;
    public Transform  FirePoint;
    float fp_x = 0.12f;
    public GameObject[] FlechaPreFab;
    public int elementoAtual;
    public int FlechasAtual;
    public float TempoRecarga = 1f;
    private bool IsReloading = false;
    
    //codigo da ui velha
    //public Text FlechaHUD;
    static public Arco arco;

    public AnimacaoPlayer anim;

    //bool para menupausa
    private bool canShoot = true;


    // private List<tipoFlecha> flechasDisponiveis = new List<tipoFlecha>();

    // serve pra saber todas as flechas q o player atirou pra ativar a função de puxar elas
    private List<GameObject> flechasAtiradas = new List<GameObject>();

    [SerializeField] AnelScroll uiAnel;
    [SerializeField] FlechaUI uiFlecha;

    // Update is called once per frame
    void Start(){
        FlechasAtual = TotalFlecha;
        playercoll = GetComponentInParent<Collider2D>();
        // flechasDisponiveis.Add(tipoFlecha.Corda);

        elementoAtual = 0;

        arco = this;
    }

    void Update()
    {
        //Debug.Log(elementoAtual);
        //calculo da direção da flecha;
        Vector2 posicaoArco = transform.position;
        Vector2 posicaoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direcao = posicaoMouse - posicaoArco;
        transform.right = direcao;

        if(Input.mousePosition.x < Screen.width/2)
        {
            anim.VirarPlayer(true);
            FirePoint.localPosition = new Vector3(-fp_x, 0f, 0f);
        } else
        {
            anim.VirarPlayer(false);
            FirePoint.localPosition = new Vector3(fp_x, 0f, 0f);
        }

        //codigo da ui velha
        //FlechaHUD.text = FlechasAtual.ToString();
        if(IsReloading){
            return;
        }

        //pode atirar
        if (canShoot && Input.GetButtonDown("Fire1"))
        {
            Shoot();
            uiFlecha.UpdateFlechaUI();
        }


        //mudança de flecha

        if(canShoot && Input.GetKeyDown(KeyCode.E)){

            if(elementoAtual < 3){
                if(Status.status.flechasLiberadas[elementoAtual + 1] == true)
                {
                    elementoAtual++;
                }
                else {
                    elementoAtual = 0;
                }
            } else {
                elementoAtual = 0;
            }
            uiAnel.SetAnel(elementoAtual);
        }


        if(canShoot && Input.GetKeyDown(KeyCode.Q)){
            if(elementoAtual > 0) 
            {
                elementoAtual--;
                uiAnel.SetAnel(elementoAtual);;
            }
            else {
                elementoAtual = Array.LastIndexOf(Status.status.flechasLiberadas, true);
            }
            uiAnel.SetAnel(elementoAtual);
        }
        

        // botao de recarregar q puxa todas as flechas na cena
        if(canShoot && Input.GetKeyDown(KeyCode.R) && gameObject.GetComponentInParent<Movimento>().grounded)
        {
            IsReloading = true;
            foreach (GameObject flecha in flechasAtiradas)
            {
                flecha.GetComponent<Flecha>().RetornarPlayer();
                FlechasAtual = TotalFlecha;
                uiFlecha.UpdateFlechaUI();
            }
            IsReloading = false;
        }

    }

    void Shoot(){
        //logica do tiro

        if(FlechasAtual > 0){
            gameObject.GetComponent<AudioSource>().Play();
            FlechasAtual--;
            GameObject novaFlecha = Instantiate(FlechaPreFab[elementoAtual], FirePoint.position, transform.rotation);

            flechasAtiradas.Add(novaFlecha);
            // qnd a flecha é atirada guardamos a referencia na lista pra puxar dps
            novaFlecha.GetComponent<Flecha>().arcoref = this;
            // da a referencia desse arco pra flecha pra ela saber pra onde voltar ao ser puxada
        }


    }

    public void AumentarFlechas()
    {
        TotalFlecha++;
    }

    // public void addTipoFlecha(tipoFlecha tipo) {
    //     flechasDisponiveis.Add(tipo);
    // }

    public void RecuperarFlecha(Flecha flechaAtirada)
    {
        if (FlechasAtual < TotalFlecha)
        {
            FlechasAtual++;
        }
        flechasAtiradas.Remove(flechaAtirada.gameObject);
    }

    public void SetCanShoot(bool value)
    {
        canShoot = value;
    }
}
