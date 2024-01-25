using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textostutorial : MonoBehaviour
{
    private ArrayList tutoriales;
    private TextMeshProUGUI tmp;
    private int actual;

    private void Awake()
    {
        tutoriales = new ArrayList();
        tutoriales.Add("Usa las teclas \"A\" y \"D\" para\r\nmoverte a la izquierda y a la\r\nderecha respectivamente");
        tutoriales.Add("Usa la tecla \"ESPACIO\" para saltar");
        tutoriales.Add("Usa la tecla \"E\" para hablar con los demas personajes");
        tutoriales.Add("Acercate al enemigo para comenzar un combate");
        tmp = GetComponent<TextMeshProUGUI>();
        actual = -1;
    }

    // Start is called before the first frame update
    void Start()
    {
        cambiarTexto();
    }


    public void cambiarTexto()
    {
        actual += 1;
        tmp.text = tutoriales[actual].ToString();
    }
}
