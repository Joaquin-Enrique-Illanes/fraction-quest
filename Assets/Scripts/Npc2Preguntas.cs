using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Npc2Pregunta : MonoBehaviour
{
    [SerializeField] private GameObject dialogoMark;
    private bool isPlayerNear;
    public Transform tr;
    public int npcPregunta;
    public int currentCoins;
    // Start is called before the first frame update
    void Start()
    {
        npcPregunta = PlayerPrefs.GetInt("valor", 0);
        currentCoins = PlayerPrefs.GetInt("Coin", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (npcPregunta == 1 && currentCoins >= 3 && currentCoins < 6)
        {
            if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
            {
                PlayerPrefs.SetFloat("x", tr.position.x);
                PlayerPrefs.SetFloat("y", tr.position.y);
                PlayerPrefs.Save();
                SceneManager.LoadScene("preguntas2");
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (npcPregunta == 1 && currentCoins >= 3 && currentCoins < 6)
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
