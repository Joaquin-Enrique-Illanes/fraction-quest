using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cargarPosicion : MonoBehaviour
{
    Transform tr;
    float x;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        if (PlayerPrefs.GetFloat("x", 1000) != 1000 )
        {
            x = PlayerPrefs.GetFloat("x", 0);
            y = PlayerPrefs.GetFloat("y", 0);
            Vector3 posicion = new Vector3 (x, y, 0);
            tr.position = posicion;
            Debug.Log(x + " " + y);
        }
    }
}
