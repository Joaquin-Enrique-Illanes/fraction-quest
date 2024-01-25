using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Npc1Pregunta : MonoBehaviour
{
    [SerializeField] private GameObject dialogoMark;
    private bool isPlayerNear;
    public Transform tr;
    public int npcPregunta;
    public int currentCoins;
    int juego = 0;
    // Start is called before the first frame update
    void Start()
    {
        juego = PlayerPrefs.GetInt("nuevo", 0);

        npcPregunta = PlayerPrefs.GetInt("valor", 0);
        currentCoins = PlayerPrefs.GetInt("Coin", 0);

        Debug.Log("valores " + npcPregunta);
        Debug.Log("monedas " + currentCoins);
    }

    // Update is called once per frame
    void Update()
    {
        if (npcPregunta < 1 && currentCoins < 3)
        {
            if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
            {
                PlayerPrefs.SetFloat("x", tr.position.x);
                PlayerPrefs.SetFloat("y", tr.position.y);
                PlayerPrefs.Save();
                if (juego == 0)
                {
                    SceneManager.LoadScene("preguntas");
                }else if (juego == 1)
                {
                    SceneManager.LoadScene("preguntas4");
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (npcPregunta < 1 && currentCoins < 3)
            {
                isPlayerNear = true;
                dialogoMark.SetActive(true);
            }
            else
            {
                isPlayerNear = false;
                dialogoMark.SetActive(false);
            }
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
}

