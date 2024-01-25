using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel2 : MonoBehaviour
{
    public GameObject panel;
    private tutorial tutorial;

    // Start is called before the first frame update
    void Start()
    {
        tutorial = panel.GetComponent<tutorial>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tutorial.siguiente();
            Destroy(this.gameObject);
        }
    }
}
