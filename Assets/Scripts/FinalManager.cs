using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalManager : MonoBehaviour
{
    [SerializeField] float duracaoFinal = 15f;
    Animator anim;
    //Collider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.parent.GetComponentInChildren<Animator>();
        //coll = GetComponentInChildren<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Movimento>().ToggleMovimento(false);
            anim.SetTrigger("FINAL");
            StartCoroutine(MudarCena());

        }
    }

    IEnumerator MudarCena()
    {
        yield return new WaitForSeconds(duracaoFinal);  // tempo para o vídeo rodar
        Status.instancia.GetComponentInChildren<Mira>().MiraAtiva(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
