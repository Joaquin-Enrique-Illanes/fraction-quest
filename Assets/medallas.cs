using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medallas : MonoBehaviour
{
    [SerializeField] private GameObject curacion;
    [SerializeField] private GameObject ataque;
    [SerializeField] private GameObject esquivar;

    int logro = 0;
    // Start is called before the first frame update
    void Start()
    {
        logro = PlayerPrefs.GetInt("valor", 0);
        if (logro >= 1)
        {
            curacion.SetActive(true);
        }
        if (logro >= 2)
        {
            ataque.SetActive(true);
        }
        if (logro >= 3)
        {
            esquivar.SetActive(true);
        }

    }
}
