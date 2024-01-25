using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcGuia : MonoBehaviour
{

    [SerializeField] private GameObject dialogoMark;
    [SerializeField] private GameObject dialogoBackground;

    private ArrayList dialogoNicolas;
    private DialogoBackground texto;
    private bool isPlayerNear;
    private int actual;

    private void Awake()
    {
        dialogoNicolas = new ArrayList();
        dialogoNicolas.Add("Bienvenido a Fraction City.");
        dialogoNicolas.Add("Aquí los ciudadanos te pondran a prueba con preguntas de fracciones.");
        dialogoNicolas.Add("Si respondes correctamente, te darán una ventaja en combate.");
        dialogoNicolas.Add("O también podrías intentar pelear sin ventajas.");
        dialogoNicolas.Add("Pero no lo recomiendo.");
        dialogoNicolas.Add("¡Buena suerte!");
        texto = dialogoBackground.GetComponent<DialogoBackground>();
        actual = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            Cambiartexto();
        }
        if (isPlayerNear == false)
        {
            dialogoBackground.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNear = true;
            dialogoMark.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNear = false;
            dialogoMark.SetActive(false);
        }
    }

    public void Cambiartexto()
    {
        actual += 1;
        if (actual >= 0 && actual < dialogoNicolas.Count)
        {
            texto.modificarTexto(dialogoNicolas[actual].ToString());
            dialogoBackground.SetActive(true);
        }
        else
        {
            dialogoBackground.SetActive(false);
            actual = -1;
        }
    }
}
