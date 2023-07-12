using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arco : MonoBehaviour
{
    public Collider2D playercoll;
    public Transform  FirePoint;
    public GameObject FlechaPreFab;
    public int TotalFlecha = 5;
    public int FlechasAtual;
    public float TempoRecarga = 1f;
    private bool IsReloading = false;
    public Text FlechaHUD;

    // Update is called once per frame

    void Start(){

        FlechasAtual = TotalFlecha;
        playercoll = GetComponentInParent<Collider2D>();
    }

    void Update()
    {
        //calculo da direção da flecha;
        Vector2 posicaoArco = transform.position;
        Vector2 posicaoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direcao = posicaoMouse - posicaoArco;
        transform.right = direcao;

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

    }

    void Shoot(){
        //logica do tiro
        FlechasAtual--;
        Instantiate(FlechaPreFab, FirePoint.position, FirePoint.rotation);
    }

    public void AumentarFlechas()
    {
        TotalFlecha++;
    }
}
