using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBattle : MonoBehaviour
{
    public string unitName;
    public int damage;

    public int maxHP;
    public int currentHP;

    public bool isDefending = false;

    public bool TakeDMG(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }    
    }
}
