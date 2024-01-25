using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class battleSystem : MonoBehaviour
{

    public int data = 1;

    public int currentCoins;

    public Button heal;
    public Button heavy;
    public Button dodgeB;

    public GameObject playerData;
    public GameObject enemyData;

    public TextMeshProUGUI dialogue;

    UnitBattle playerUnit;
    UnitBattle enemyUnit;

    public BattleHub playerHub;
    public BattleHub enemyHub;

    Animator atk;
    Animator atkE;
    Animator healing;
    Animator hurt;
    Animator deadP;
    Animator deadE;
    Animator dodge;
    Animator block;

    bool turnChange = false;

    public int valoresX = 0;

    public BattleState state;
    void Start()
    {
        currentCoins = PlayerPrefs.GetInt("Coin", 0);
        /*PlayerPrefs.DeleteKey("Coin");
        PlayerPrefs.Save();*/
        state = BattleState.START;
        StartCoroutine(SetBattle());
    }

    void Update()
    {
        if (currentCoins >= 3)
        {
            heal.interactable = true;
        }
        else
        {
            heal.interactable = false;
        }
        if (currentCoins >= 6)
        {
            heavy.interactable = true;
        }
        else
        {
            heavy.interactable = false;
        }
        if (currentCoins >= 9)
        {
            dodgeB.interactable = true;
        }
        else
        {
            dodgeB.interactable = false;
        }
    }

    IEnumerator SetBattle()
    {
        GameObject PlayerGo = playerData;
        playerUnit = PlayerGo.GetComponent<UnitBattle>();

        GameObject EnemyGo = enemyData;
        enemyUnit = EnemyGo.GetComponent<UnitBattle>();

        dialogue.text = "Te topaste con " + enemyUnit.unitName;

        playerHub.SetHUD(playerUnit);
        enemyHub.SetHUD(enemyUnit);

        Debug.Log(currentCoins);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogue.fontSize = 30;
        dialogue.text = "Elige una acción";
    }

    public void AttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        if (!turnChange)
            StartCoroutine(PlayerAttack());
    }

    public void HealkButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        if (!turnChange)
            StartCoroutine(PlayerHeal());
    }

    public void HeavyAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        if (!turnChange)
            StartCoroutine(HeavyPlayerAttack());
    }

    public void DodgeButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        if (!turnChange)
            StartCoroutine(Dodge());
    }

    IEnumerator PlayerHeal()
    {
        turnChange = true;
        playerUnit.Heal(5);

        healing = playerUnit.GetComponent<Animator>();
        healing.SetBool("heal", true);

        playerHub.SetHP(playerUnit.currentHP);
        dialogue.text = "¡Recuperaste vida!";

        yield return new WaitForSeconds(1f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
        turnChange = false;
    }

    IEnumerator PlayerAttack()
    {
        turnChange = true;
        if (!enemyUnit.isDefending)
        {
            bool dead = enemyUnit.TakeDMG(playerUnit.damage);

            enemyHub.SetHP(enemyUnit.currentHP);

            atk = playerUnit.GetComponent<Animator>();
            atk.SetBool("attack", true);

            hurt = enemyUnit.GetComponent<Animator>();
            hurt.SetBool("hurt", true);

            dialogue.text = "¡Buen golpe!";

            yield return new WaitForSeconds(1f);

            if (dead)
            {

                deadE = enemyUnit.GetComponent<Animator>();
                deadE.SetBool("dead", true);
                yield return new WaitForSeconds(1f);
                state = BattleState.WON;
                EndBattle();
            }
            else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            }
        }
        else
        {
            atk = playerUnit.GetComponent<Animator>();
            atk.SetBool("attack", true);

            block = enemyUnit.GetComponent<Animator>();
            block.SetBool("block", true);

            dialogue.text = "Prueba con algo mas fuerte.";
            yield return new WaitForSeconds(2f);
            dialogue.text = "es invensible ahora";
            yield return new WaitForSeconds(2f);
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        turnChange = false;

    }

    IEnumerator HeavyPlayerAttack()
    {
        turnChange = true;
        if (enemyUnit.currentHP <= 3)
        {
            atk = playerUnit.GetComponent<Animator>();
            atk.SetBool("heavyAttack", true);

            enemyUnit.isDefending = false;
            TextMeshProUGUI fontS = dialogue.GetComponent<TextMeshProUGUI>();
            dialogue.text = "¡Has roto su invensivilidad!";
            yield return new WaitForSeconds(2f);
            fontS.fontSize = 25;
            fontS.text = "¡Es tu oportunidad!";
            yield return new WaitForSeconds(2f);
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
        else
        {
            dialogue.text = "Fallaste pa!";
            atk = playerUnit.GetComponent<Animator>();
            atk.SetBool("heavyAttack", true);
            yield return new WaitForSeconds(2f);
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        turnChange = false;
    }


    IEnumerator Dodge()
    {
        turnChange = true;
        playerUnit.isDefending = true;

        playerHub.SetHP(playerUnit.currentHP);

        dialogue.text = "Te preparas para esquivar.";
        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
        turnChange = false;
    }

    IEnumerator EnemyTurn()
    {
        //Activar para pelea 3
        if (SceneManager.GetActiveScene().name == "pelea3" || SceneManager.GetActiveScene().name == "pelea4")
        {
            if (enemyUnit.currentHP == 3)
            {
                enemyUnit.isDefending = true;
            }
        }
        //--------------------------------------------------------------------------------------
        if (!playerUnit.isDefending)
        {
            dialogue.text = enemyUnit.unitName + " va a atacar.";
            bool dead = playerUnit.TakeDMG(enemyUnit.damage);
            playerHub.SetHP(playerUnit.currentHP);
            if (enemyUnit.damage < 10)
            {
                atkE = enemyUnit.GetComponent<Animator>();
                atkE.SetBool("attack", true);
            }
            else
            {
                atkE = enemyUnit.GetComponent<Animator>();
                atkE.SetBool("heavyAttack", true);
            }

            hurt = playerUnit.GetComponent<Animator>();
            hurt.SetBool("hurt", true);
            //Activo en batalla final
            if (SceneManager.GetActiveScene().name == "pelea4")
            {
                if (enemyUnit.currentHP == 2)
                {
                    enemyUnit.damage = 10;
                    yield return new WaitForSeconds(1f);
                    dialogue.text = enemyUnit.unitName + " esta cargando un ataque potente";
                    yield return new WaitForSeconds(2f);
                    dialogue.text = enemyUnit.unitName + " que te va a derrotar";
                }
            }
            //---------------------------
            yield return new WaitForSeconds(1f);

            if (dead)
            {
                deadP = playerUnit.GetComponent<Animator>();
                deadP.SetBool("dead", true);
                yield return new WaitForSeconds(1f);
                state = BattleState.LOST;
                EndBattle();
            }
            else
            {
                state = BattleState.PLAYERTURN;
                PlayerTurn();
            }
        }
        else
        {
            dialogue.text = "!Bien hecho!";
            atkE = enemyUnit.GetComponent<Animator>();
            atkE.SetBool("heavyAttack", true);

            dodge = playerUnit.GetComponent<Animator>();
            dodge.SetBool("dodge", true);
            //Activo en batalla final
            if (SceneManager.GetActiveScene().name == "pelea4")
            {
                enemyUnit.damage = 1;
            }
            //--------------------------
            playerUnit.isDefending = false;
            yield return new WaitForSeconds(2f);
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }
    void EndBattle()
    {
        PlayerPrefs.DeleteKey("x");
        PlayerPrefs.DeleteKey("y");
        PlayerPrefs.Save();
        if (state == BattleState.WON)
        {
            dialogue.text = "¡Victoria!";
            if (SceneManager.GetActiveScene().name == "pelea")
            {
                SceneManager.LoadScene("nivelAlfa");
            }
            else if (SceneManager.GetActiveScene().name == "pelea2")
            {
                valoresX = 1;
                PlayerPrefs.SetInt("valor", valoresX);
                PlayerPrefs.Save();
                SceneManager.LoadScene("victoriaPelea");
            }
            else if (SceneManager.GetActiveScene().name == "pelea3")
            {
                valoresX = 2;
                PlayerPrefs.DeleteKey("valor");
                PlayerPrefs.Save();
                PlayerPrefs.SetInt("valor", valoresX);
                PlayerPrefs.Save();
                SceneManager.LoadScene("victoriaPelea");
            }
            else if (SceneManager.GetActiveScene().name == "pelea4")
            {
                valoresX = 3;
                /*PlayerPrefs.DeleteKey("valor");
                PlayerPrefs.DeleteKey("Coin");
                // PlayerPrefs.Save();*/
                PlayerPrefs.DeleteKey("valor");
                PlayerPrefs.Save();
                PlayerPrefs.SetInt("valor", valoresX);
                PlayerPrefs.Save();
                SceneManager.LoadScene("victoriaPelea");
            }
        }
        else if (state == BattleState.LOST)
        {
            dialogue.text = "Intentalo otra vez.";
            SceneManager.LoadScene("nivelAlfa");
        }
    }
}