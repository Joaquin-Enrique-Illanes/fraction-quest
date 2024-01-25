using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static Unity.Burst.Intrinsics.X86.Avx;

public class npcTutorial : MonoBehaviour
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
        dialogoNicolas.Add("Saludos valiente visitante.");
        dialogoNicolas.Add("Lamentablemente, nos encontramos en tiempos oscuros.");
        dialogoNicolas.Add("Varios monstruos han invadido nuestras tierras, y la desesperación se cierne sobre nosotros.");
        dialogoNicolas.Add("Te pido que si visitas nuestra ciudad puedas luchar por nosotros.");
        dialogoNicolas.Add("Hay muchos peligros mas adelante, los aldeanos pueden ayudarte si te consideran digno.");
        dialogoNicolas.Add("Te preguntarán sobre fracciones, si respondes correctamente obtendrás habilidades de combate.");
        dialogoNicolas.Add("Aunque no te detendré si deseas luchar solo con tus habilidades actuales.");
        dialogoNicolas.Add("Yo no lo recomendaría.");
        dialogoNicolas.Add("Más adelante encontrarás a un enemigo. ¡Mucha suerte!");
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
