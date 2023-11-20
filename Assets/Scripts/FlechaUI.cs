using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlechaUI : MonoBehaviour
{
    List<Image> FlechaHUDImages;
    public Arco arco;

    public GameObject flechaIMG;

    private void Start()
    {
        
        if (arco == null)
        {
            Debug.LogError("Arco não está atribuído ao UIFlechaManager.");
        }

        FlechaHUDImages = new List<Image>();
        for(int i = 0; i < arco.TotalFlecha; i++)
        {
            FlechaHUDImages.Add(Instantiate(flechaIMG, this.transform).GetComponent<Image>());
        }

        UpdateFlechaUI();

    }

    public void UpdateFlechaUI()
    {
        
        for(int i = 0; i < arco.TotalFlecha; i++)
        {
            if(i < arco.FlechasAtual)
            {
                FlechaHUDImages[i].enabled = true;
            } else
            {
                FlechaHUDImages[i].enabled = false;
            }
        }
    }

    public void AddIMG()
    {
        FlechaHUDImages.Add(Instantiate(flechaIMG, this.transform).GetComponent<Image>());
        UpdateFlechaUI();
    }
}
