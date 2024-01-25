using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class VerificarRespuesta : MonoBehaviour
{
    [SerializeField] private GameObject error;
    public int coins = 0;
    public Manager respuestaActual;
    private int correctas = 0;
    public UnityEvent lose;

    public GameObject nextQuestion;
    int oportunidades =5;

    public TextMeshProUGUI respuestaBoton1;
    public TextMeshProUGUI respuestaBoton2;
    public TextMeshProUGUI respuestaBoton3;
    public TextMeshProUGUI respuestaBoton4;

    public void Verificar(int opcion)
    {
        string respuestaIngresada = "";

        switch (opcion)
        {
            case 1:
                respuestaIngresada = respuestaBoton1.text.Trim();
                break;
            case 2:
                respuestaIngresada = respuestaBoton2.text.Trim();
                break;
            case 3:
                respuestaIngresada = respuestaBoton3.text.Trim();
                break;
            case 4:
                respuestaIngresada = respuestaBoton4.text.Trim();
                break;
        }

        if (respuestaIngresada.Equals(respuestaActual.textoRespuestaCorrecta))
        {
            Debug.Log("¡Respuesta correcta!");
            oportunidades--;
            correctas++;
            if(SceneManager.GetActiveScene().name == "preguntas" || SceneManager.GetActiveScene().name == "preguntas4")
            {
                coins++;

            }else if (SceneManager.GetActiveScene().name == "preguntas2" || SceneManager.GetActiveScene().name == "preguntas5")
            {
                coins+=2;
            }else if (SceneManager.GetActiveScene().name == "preguntas3" || SceneManager.GetActiveScene().name == "preguntas6")
            {
                coins+=3;
            }
                if (oportunidades > 0 && correctas < 3)
            {   
                nextQuestion.GetComponent<Manager>().nextQ();
            }
            else
            {
                PlayerPrefs.SetInt("Coin", coins);
                PlayerPrefs.Save();
                ganarPreguntas();
            }
        }
        else
        {
            Debug.Log("Respuesta incorrecta.");
            oportunidades--;
            if (oportunidades > 0)
            {
                StartCoroutine(esperar());
            }
            else
            {
                PerderJuego();
            }
        }
    }

    IEnumerator esperar()
    {
        error.SetActive(true);
        yield return new WaitForSeconds(3f);
        error.SetActive(false);
        nextQuestion.GetComponent<Manager>().nextQ();
    }
    public void ganarPreguntas()
    {
        Debug.Log("¡Juego pausado debido a respuesta terminadas!");
        SceneManager.LoadScene("victoria");
    }
    public void PerderJuego()
    {
        StartCoroutine(esperar());
        Debug.Log("¡Juego pausado debido a respuesta incorrecta!");
        SceneManager.LoadScene("derrota");
    }
}
