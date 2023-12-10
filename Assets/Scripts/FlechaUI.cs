using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlechaUI : MonoBehaviour
{
    List<Image> FlechaHUDImages;

    public GameObject flechaIMG;

    private void Awake()
    {

        FlechaHUDImages = new List<Image>();
        for(int i = 0; i < Status.instancia.totalFlechas; i++)
        {
            FlechaHUDImages.Add(Instantiate(flechaIMG, this.transform).GetComponent<Image>());
        }
    }

    public void UpdateFlechaUI(int flechasDisponiveis)
    {
        
        for(int i = 0; i < Status.instancia.totalFlechas; i++)
        {
            if(i < flechasDisponiveis)
            {
                FlechaHUDImages[i].enabled = true;
            } else
            {
                FlechaHUDImages[i].enabled = false;
            }
        }
    }

    public void AddIMG(int flechasDisponiveis)
    {
        FlechaHUDImages.Add(Instantiate(flechaIMG, this.transform).GetComponent<Image>());
        UpdateFlechaUI(flechasDisponiveis);
    }
}
