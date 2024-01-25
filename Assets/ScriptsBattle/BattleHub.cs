using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHub : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public Slider hpSlider;
    public TextMeshProUGUI currentHPText;
    string aux;

    public void SetHUD(UnitBattle unit)
    {
        nameText.text = unit.unitName;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;

       aux = unit.currentHP.ToString();
        currentHPText.text = aux;

    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;

        aux = hp.ToString();
        currentHPText.text = aux;
    }
}
