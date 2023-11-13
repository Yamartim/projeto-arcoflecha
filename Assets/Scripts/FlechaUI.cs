using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlechaUI : MonoBehaviour
{
    public Image[] FlechaHUDImages;
    public Arco arco;

    public Image Flecha1; 
    public Image Flecha2;
    public Image Flecha3;
    public Image Flecha4;
    public Image Flecha5;

    private void Start()
    {
        if (arco == null)
        {
            Debug.LogError("Arco não está atribuído ao UIFlechaManager.");
        }
    }

    private void Update()
    {
        UpdateFlechaUI();
    }

    private void UpdateFlechaUI()
    {
        int flechasDisponiveis = arco.FlechasAtual;

        Flecha1.enabled = (flechasDisponiveis >= 1);
        Flecha2.enabled = (flechasDisponiveis >= 2);
        Flecha3.enabled = (flechasDisponiveis >= 3);
        Flecha4.enabled = (flechasDisponiveis >= 4);
        Flecha5.enabled = (flechasDisponiveis >= 5);
    }
}
