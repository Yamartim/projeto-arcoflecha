using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class MenuOpcoes : MonoBehaviour
{
    public AudioMixer Audio;
    public TMP_Dropdown DropdownResolucao;
    
    Resolution[] resolutions;
    
    void Start ()
    {
        resolutions = Screen.resolutions;
        DropdownResolucao.ClearOptions();
        List<string> options = new List<string>();
        
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option) ;

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution. height)
            {   
                currentResolutionIndex = i;
            }
        }

        DropdownResolucao.AddOptions(options) ;
        DropdownResolucao.value = currentResolutionIndex;
        DropdownResolucao.RefreshShownValue( ) ;
        
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions [resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }

    public void SetVolumeMsc (float Musica){

        Audio.SetFloat("MusicaVolume", Musica);

    }

    public void SetVolumeEft (float Efeitos){

        Audio.SetFloat("EfeitosVolume", Efeitos);

    }

    public void SetFullscreen (bool cheia){

        Screen.fullScreen = cheia;
    }
}
