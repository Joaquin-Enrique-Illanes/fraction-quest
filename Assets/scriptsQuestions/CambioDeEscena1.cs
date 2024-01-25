using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
   
    public Transform puntoInicio;

    private void Start()
    {
        
        if (puntoInicio != null)
        {
            UnitBattle player = FindObjectOfType<UnitBattle>();
            if (player != null)
            {
                player.transform.position = puntoInicio.position;
                player.transform.rotation = puntoInicio.rotation;
            }
        }
    }
}

