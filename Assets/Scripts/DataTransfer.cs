using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DataTransfer : MonoBehaviour
{
    public static DataTransfer Instance;

    public int enemigosDerrotados;

    [SerializeField] private GameObject Lancer;
    [SerializeField] private GameObject Shield;

    private void Start()
    {
        enemigosDerrotados = PlayerPrefs.GetInt("valor",0);
        if (enemigosDerrotados >= 1)
        {
            Lancer.SetActive(false);

        }if (enemigosDerrotados >= 2)
        {
            Shield.SetActive(false);
        }
    }
}
