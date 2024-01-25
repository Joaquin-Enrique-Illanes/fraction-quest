using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject boxPausa;
    [SerializeField] private GameObject menuConfirmar;

    public void Pausa()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        boxPausa.SetActive(true);
    }

    public void reanudar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        boxPausa.SetActive(false);
    }

    public void confirmar()
    {
        menuConfirmar.SetActive(true);
    }

    public void volver()
    {
        menuConfirmar.SetActive(false);
    }

    public void salir()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menuPrincipal");
    }
}
