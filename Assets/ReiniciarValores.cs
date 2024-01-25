using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReiniciarValores : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("valor");
        PlayerPrefs.DeleteKey("Coin");
        PlayerPrefs.DeleteKey("x");
        PlayerPrefs.DeleteKey("y");
        PlayerPrefs.DeleteKey("nuevo");
        PlayerPrefs.Save();
    }
}
