using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arco : MonoBehaviour
{
    //esse total de flechas dps tem q ir pra classe de stats do jogador
    public int TotalFlecha = 5;

    public Collider2D playercoll;
    public Transform  FirePoint;
    public GameObject[] FlechaPreFab;
    public int elementoAtual;
    public int FlechasAtual;
    public float TempoRecarga = 1f;
    private bool IsReloading = false;
    public Text FlechaHUD;
    static public Arco arco;

    private List<tipoFlecha> flechasDisponiveis = new List<tipoFlecha>();

    private List<GameObject> flechasAtiradas = new List<GameObject>();

    // Update is called once per frame
    void Start(){
        FlechasAtual = TotalFlecha;
        playercoll = GetComponentInParent<Collider2D>();
        flechasDisponiveis.Add(tipoFlecha.Corda);

        elementoAtual = 0;

        arco = this;
    }

    void Update()
    {
        //calculo da direção da flecha;
        Vector2 posicaoArco = transform.position;
        Vector2 posicaoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direcao = posicaoMouse - posicaoArco;
        transform.right = direcao;

        if(Input.mousePosition.x < Screen.width/2)
            transform.parent.localScale = new Vector3 (-5, 5, 1);
        else
            transform.parent.localScale = new Vector3 (5, 5, 1);

        FlechaHUD.text = FlechasAtual.ToString();
        if(IsReloading){
            return;
        }

        if(FlechasAtual <= 0){
            StartCoroutine(Reload());
            return;
        }

        if(Input.GetButtonDown("Fire1")){

            Shoot();
        }

        IEnumerator Reload(){
            IsReloading = true;

            Debug.Log("Carregando..");
            yield return new WaitForSeconds(TempoRecarga);
            FlechasAtual = TotalFlecha;

            IsReloading = false;
        }

        //mudança de flecha

        if(Input.GetKeyDown(KeyCode.E)){

            if(elementoAtual < 3){
                elementoAtual++;
            }
        }
        if(Input.GetKeyDown(KeyCode.Q)){

            if(elementoAtual > 0){
                elementoAtual--;
            }
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            foreach (GameObject flecha in flechasAtiradas)
            {
                flecha.GetComponent<Flecha>().RetornarPlayer();
            }
        }

    }

    void Shoot(){
        //logica do tiro
        //gameObject.GetComponentInParent<EfeitosSonoros>().playAtirarFlecha();
        FlechasAtual--;
        GameObject novaFlecha = Instantiate(FlechaPreFab[elementoAtual], FirePoint.position, transform.rotation);

        flechasAtiradas.Add(novaFlecha);
        novaFlecha.GetComponent<Flecha>().arcoref = this;


    }

    public void AumentarFlechas()
    {
        TotalFlecha++;
    }

    public void addTipoFlecha(tipoFlecha tipo) {
        flechasDisponiveis.Add(tipo);
    }

    public void RecuperarFlecha(Flecha flechaAtirada)
    {
        if (FlechasAtual < TotalFlecha)
        {
            FlechasAtual++;
        }
        flechasAtiradas.Remove(flechaAtirada.gameObject);
    }
}
