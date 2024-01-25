
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public textostutorial texto;

    // Start is called before the first frame update
    void Start()
    {
        activar();
    }


    public void desactivar()
    {
        this.gameObject.SetActive(false);
    }
    public void activar()
    {
        this.gameObject.SetActive(true);
    }
    public void siguiente()
    {
        activar();
        texto.cambiarTexto();
    }
}
