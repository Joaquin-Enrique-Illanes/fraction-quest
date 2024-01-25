using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaEnemigo : MonoBehaviour
{

    private bool isPlayerNear;
    public UnitBattle enemigo;

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNear)
        {
            if (enemigo.unitName.Equals("Lancer"))
            {
                SceneManager.LoadScene("pelea2");
            }
            else if (enemigo.unitName.Equals("Shield"))
            {
                SceneManager.LoadScene("pelea3");
            }
            else if (enemigo.unitName.Equals("Boss"))
            {
                SceneManager.LoadScene("pelea4");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}
