using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Arco : MonoBehaviour
{

    Status player;
    int TotalFlecha;

    public Collider2D playercoll;
    public Transform  FirePoint;
    float fp_x = 0.12f;
    public GameObject[] FlechaPreFab;
    public int anelAtual;
    public int flechasAtual;
    public float TempoRecarga = 1f;
    private bool IsReloading = false;
    
    //codigo da ui velha
    //public Text FlechaHUD;
    static public Arco arco;

    public AnimacaoPlayer anim;
    public Mira mira;

    //bool para menupausa
    private bool canShoot = true;


    // private List<tipoFlecha> flechasDisponiveis = new List<tipoFlecha>();

    // serve pra saber todas as flechas q o player atirou pra ativar a função de puxar elas
    private List<GameObject> flechasAtiradas = new List<GameObject>();

    [SerializeField] AnelScroll uiAnel;
    [SerializeField] FlechaUI uiFlecha;
    [SerializeField] EventSystem eventSystem;

    // Update is called once per frame
    void Start(){
        player = GetComponentInParent<Status>();

        TotalFlecha = player.totalFlechas;
        flechasAtual = TotalFlecha;
        playercoll = GetComponentInParent<Collider2D>();
        // flechasDisponiveis.Add(tipoFlecha.Corda);

        anelAtual = 0;

        arco = this;
        
        uiFlecha.UpdateFlechaUI(flechasAtual);

    }

    void Update()
    {

        //Debug.Log(elementoAtual);
        //calculo da direção da flecha;
        Vector2 posicaoArco = transform.position;
        Vector2 posicaoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direcao = posicaoMouse - posicaoArco;
        transform.right = direcao;

        if(mira.transform.position.x < gameObject.transform.position.x)
        {
            anim.VirarPlayer(true);
            FirePoint.localPosition = new Vector3(-fp_x, 0f, 0f);
        } else
        {
            anim.VirarPlayer(false);
            FirePoint.localPosition = new Vector3(fp_x, 0f, 0f);
        }

        if(IsReloading){
            return;
        }

#region input de atirar
        //pode atirar
        if (canShoot && Input.GetButtonDown("Fire1") && !eventSystem.IsPointerOverGameObject())
        {
            Shoot();
            uiFlecha.UpdateFlechaUI(flechasAtual);
        }

#endregion

#region input de trocar de flecha

        if(canShoot && Input.GetKeyDown(KeyCode.E)){

            if(anelAtual < 3){
                if(player.aneisLiberados[anelAtual + 1] == true)
                {
                    anelAtual++;
                }
                else {
                    anelAtual = 0;
                }
            } else {
                anelAtual = 0;
            }
            uiAnel.SetAnel(anelAtual);
        }


        if(canShoot && Input.GetKeyDown(KeyCode.Q)){
            if(anelAtual > 0) 
            {
                anelAtual--;
                uiAnel.SetAnel(anelAtual);;
            }
            else {
                anelAtual = Array.LastIndexOf(player.aneisLiberados, true);
            }
            uiAnel.SetAnel(anelAtual);
        }

#endregion

#region input de recarregar

        // botao de recarregar q puxa todas as flechas na cena
        if(canShoot && Input.GetKeyDown(KeyCode.R) && gameObject.GetComponentInParent<Movimento>().grounded)
        {
            IsReloading = true;
            foreach (GameObject flecha in flechasAtiradas)
            {
                flecha.GetComponent<Flecha>().RetornarPlayer();
                flechasAtual = TotalFlecha;
                uiFlecha.UpdateFlechaUI(flechasAtual);
            }
            IsReloading = false;
        }

#endregion

    }

    void Shoot(){
        //logica do tiro

        if(flechasAtual > 0){
            gameObject.GetComponent<AudioSource>().Play();
            flechasAtual--;
            GameObject novaFlecha = Instantiate(FlechaPreFab[anelAtual], FirePoint.position, transform.rotation);

            flechasAtiradas.Add(novaFlecha);
            // qnd a flecha é atirada guardamos a referencia na lista pra puxar dps
            novaFlecha.GetComponent<Flecha>().arcoref = this;
            // da a referencia desse arco pra flecha pra ela saber pra onde voltar ao ser puxada
        }


    }

    public void AumentarFlechas()
    {
        player.AumentarTotalFlechas();
        TotalFlecha = player.totalFlechas;
        flechasAtual++;
        uiFlecha.AddIMG(flechasAtual);
    }

    public void RecuperarFlecha(Flecha flechaAtirada)
    {
        if (flechasAtual < TotalFlecha)
        {
            flechasAtual++;
        }
        flechasAtiradas.Remove(flechaAtirada.gameObject);
    }

    public void SetCanShoot(bool value)
    {
        canShoot = value;
    }
}
