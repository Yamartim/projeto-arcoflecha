using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ProximaCena : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CarregarMenu());
    }

    IEnumerator CarregarMenu() {
        yield return new WaitForSeconds(22.0f);  // tempo para o vídeo rodar
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
