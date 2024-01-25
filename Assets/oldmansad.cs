using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class oldmansad : MonoBehaviour
{
    [SerializeField] private GameObject fallo;
    public Transform objetivo;
    private bool llegada = false;
    private Animator animator;
    public float velocidad = 3f;
    int cartel;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cartel = PlayerPrefs.GetInt("Coin", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (llegada)
        {
            fallo.SetActive(true);

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

    IEnumerator esperar()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("nivelAlfa");
    }

}

