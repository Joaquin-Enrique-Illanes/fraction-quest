using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    int game = 1;

    private void Start()
    {
        PlayerPrefs.DeleteKey("Coin");
        PlayerPrefs.DeleteKey("valor");
        PlayerPrefs.Save();
    }
    public void dificil()
    {
        PlayerPrefs.SetInt("nuevo", game);
        SceneManager.LoadScene("nivelAlfa");
    }

    public void normal()
    {
        SceneManager.LoadScene("tutorial");
    }

    public void salir()
    {
        Debug.Log("salir");
        Application.Quit();
    }
}
