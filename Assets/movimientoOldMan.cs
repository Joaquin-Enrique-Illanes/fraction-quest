using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movimientoOldMan : MonoBehaviour
{
    [SerializeField] private GameObject curacion;
    [SerializeField] private GameObject ataque;
    [SerializeField] private GameObject esquivar;
    int valor = 1;
    public Transform objetivo;
    private bool llegada = false;
    private Animator animator;
    public float velocidad = 3f;
    int cartel;

    // Start is called before the first frame update
    void Start()
    {
        valor = PlayerPrefs.GetInt("valor", 0);
        animator = GetComponent<Animator>();
        cartel = PlayerPrefs.GetInt("Coin", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (llegada)
        {
            animator.SetBool("destino", true);
            if (SceneManager.GetActiveScene().name == "victoria")
            {
                if (cartel == 3)
                {
                    curacion.SetActive(true);
                }
                if (cartel == 6)
                {
                    ataque.SetActive(true);
                }
                if (cartel == 9)
                {
                    esquivar.SetActive(true);
                }
            }
            else if (SceneManager.GetActiveScene().name == "victoriaPelea")
            {
                if (valor == 1)
                {
                    curacion.SetActive(true);
                }
                else if (valor == 2)
                {
                    ataque.SetActive(true);
                }
                else if (valor == 3)
                {
                    esquivar.SetActive(true);
                }
            }
        }
        if (llegada == false)
        {
            animator.SetBool("destino", false);
            Vector3 direccion = objetivo.position - transform.position;
            direccion.Normalize();
            transform.Translate(direccion * velocidad * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(animator.GetBool("destino"));
        if (collision.gameObject.CompareTag("punto"))
        {
            llegada = true;
            animator.SetBool("destino", true);
            Debug.Log(animator.GetBool("destino"));
            StartCoroutine(esperar());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("punto"))
        {
            llegada = false;
        }
    }

    IEnumerator esperar() {
        yield return new WaitForSeconds(3f);
        if (valor == 3)
        {
            SceneManager.LoadScene("menuNewGame");
        }
        else
        {
            SceneManager.LoadScene("nivelAlfa");
        }
    }

}
