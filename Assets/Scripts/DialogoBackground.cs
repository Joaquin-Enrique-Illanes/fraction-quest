using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogoBackground : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;

    public void modificarTexto(string texto)
    {
        textMeshProUGUI.text = texto;
    }
}
