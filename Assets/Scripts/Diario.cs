using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Diario : MonoBehaviour
{
    public Diario Coleta;
    [SerializeField] float pageSpeed = 0.1f;
    [SerializeField] List<Transform> paginas;
    int index = -1;
    bool rotate = false;
    [SerializeField] GameObject AnteriorButton;
    [SerializeField] GameObject ProximoButton;
    int paginasColetadas = 0; // Contagem de páginas coletad

    private void Start()
    {
        InitialState();
        Time.timeScale = 1f;
    }

    public void InitialState()
    {
        for (int i = 0; i < paginas.Count; i++)
        {
            paginas[i].transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        paginas[0].SetAsLastSibling();
        AnteriorButton.SetActive(false);
    }

    public void Proximo()
    {
        if (rotate == true || paginasColetadas <= index) { return; }
        index++;
        float angle = -180;
        ProximoButtonActions();
        paginas[index].SetAsLastSibling();
        StartCoroutine(Rotate(angle, true));
    }

    public void ProximoButtonActions()
    {
        if (AnteriorButton.activeInHierarchy == false)
        {
            AnteriorButton.SetActive(true);
        }
        if (index == paginas.Count - 1 || index >= paginasColetadas)
        {
            ProximoButton.SetActive(false);
        }
    }

    public void Anterior()
    {
        if (rotate == true) { return; }
        float angle = 0;
        paginas[index].SetAsLastSibling();
        AnteriorButtonActions();
        StartCoroutine(Rotate(angle, false));
    }

    public void AnteriorButtonActions()
    {
        if (ProximoButton.activeInHierarchy == false)
        {
            ProximoButton.SetActive(true);
        }
        if (index - 1 == -1)
        {
            AnteriorButton.SetActive(false);
        }
    }

    IEnumerator Rotate(float angle, bool Proximo)
    {
        float value = 0f;
        while (true)
        {
            rotate = true;
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            value += Time.deltaTime * pageSpeed;
            paginas[index].localRotation = Quaternion.Slerp(paginas[index].localRotation, targetRotation, value);
            float angle1 = Quaternion.Angle(paginas[index].localRotation, targetRotation);
            if (angle1 < 0.1f)
            {
                if (Proximo == false)
                {
                    index--;
                }
                rotate = false;
                break;
            }
            yield return null;
        }
    }

    public void ColetarPagina()
    {
        if (index >= 0 && index < paginas.Count)
        {
            paginasColetadas++;
            Debug.Log("Pagina coletada. Total de paginas coletadas: " + paginasColetadas);
            ProximoButton.SetActive(true);
        }

        if (paginasColetadas < paginas.Count)
        {
            paginasColetadas++;
            ProximoButton.SetActive(true);
        }
    }

}