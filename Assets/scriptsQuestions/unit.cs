using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour
{
    public string unitName;
    public int HP;
    public int DMG;
    public int HP_actual;
    public GameObject ojete;

    public int TakeDamage(int dmg)
    {
       return HP_actual -= dmg;
    }
}
