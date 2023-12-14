using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoTutorial : MonoBehaviour
{
    [SerializeField] GameObject painelTutorial;
    Status player;

    void Start()
    {
        player = Status.instancia;
    }

    public void ToggleTutorial(bool toggle)
    {
        painelTutorial.SetActive(toggle);
        player.ToggleMovMira(!toggle);
        PausaMenu.podePausar = !toggle;
    }

}
