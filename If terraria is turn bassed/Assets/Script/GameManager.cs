using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = System.Object;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    #region Referencing

    public Player PS;
    public SlimeKing SK;
    public GameObject failed;
    public GameObject UIMain;
    public GameObject UIAttack;
    public GameObject UIPotion;
    public GameObject PlayerUI;
    public GameObject BossUI;
    public float BossAction;
    public TextMeshProUGUI HealthPotionNumber;
    public TextMeshProUGUI IronSkinPotionNumber;
    public TextMeshProUGUI SlimeText;
    public GameObject PlayertextObject;
    public float turn = 1f;
    public Animator Player;
    public Animator Boss;
    [SerializeField] private Turn turnS;
    public GameObject Mini1;
    public GameObject Mini2;
    public DodgeMiniGame_1 DM1;
    

    #endregion

    public enum Turn
    {
        player,
        boss,
    }

    public void Update()
    {
        
        if (turn == 1)
        {
           SetState(Turn.player); 
        }
        if (turn == 2)
        {
            SetState(Turn.boss);
           
        }
       

        if (PS.playrHealth <= 0f)
        {
            FleeUI();
        }

        if (PS.playrHealth >= 100f)
        {
            PS.playrHealth = 100f;
        }

        if (SK.slimeKingHealth <= 0f)
        {
            Debug.Log("Defeated");
        }

        HealthPotionNumber.text = PS.healthPotionNumber.ToString();
        IronSkinPotionNumber.text = PS.IronPotionNumber.ToString();
        if (turn == 1f)
        {
            PlayerUI.SetActive(true);
            BossUI.SetActive(false);
        }

        if (turn == 2f)
        {
            BossUI.SetActive(true);
            PlayerUI.SetActive(false);

        }

        if (PS.playrHealth <= 0)
        {
            FleeUI();
        }

        if (SK.slimeKingHealth <= 0)
        {
            SceneManager.LoadScene("Win");
        }
        
        
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            teleport();
            Debug.Log("SKill1");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            squash();
            Debug.Log("SKill2");
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            SlimeTurnEnd();
            Debug.Log("DebugSwitchTurn");
        }
    }

    #region UI

    public void FleeUI()
    {
        failed.SetActive(true);
    }

    public void BackUI()
    {
        UIAttack.SetActive(false);
        UIPotion.SetActive(false);
        UIMain.SetActive(true);
    }

    public void AttackUI()
    {
        UIMain.SetActive(false);
        UIAttack.SetActive(true);
    }

    public void PotionUI()
    {
        UIMain.SetActive(false);
        UIPotion.SetActive(true);
    }

    #endregion

    #region AttackUI

    public void Meele()
    {
        SK.slimeKingHealth -= 50;
        PS.ArmorPoint -= 20;
        if (PS.ArmorPoint <= 0)
        {
            PS.playrHealth -= 20;
        }
        PlayerTurnEnd();
        PS.SetState(global::Player.PlayerState.Melee);
    }

    public void Bow()
    {
        SK.slimeKingHealth -= 30;
        PlayerTurnEnd();
        PS.SetState(global::Player.PlayerState.Bow);
    }

    #endregion

    #region potion

    public void Heal()
    {
        if (PS.healthPotionNumber >= 1)
        {
            PS.playrHealth += 30;
            PS.healthPotionNumber -= 1;
            PlayerTurnEnd();
            PS.SetState(global::Player.PlayerState.Drink);
        }
    }

    public void Iron()
    {
        if (PS.IronPotionNumber >= 1)
        {
            PS.ArmorPoint += 50;
            PS.IronPotionNumber -= 1;
            PlayerTurnEnd();
            PS.SetState(global::Player.PlayerState.Drink);
        }
    }

    #endregion

    #region SlimeAttack

    public void squash()
    {
        SlimeText.text = "King Slime Used Squash...";
        Invoke("TextClear",3f); 
        Invoke("Spawn1",3f);
    }

    public void teleport()
    {
        SlimeText.text = "King Slime teleported...";
        Invoke("TextClear",3f); 
        Invoke("Spawn2",3f);
    }

    // public void summon()
    //{
    //  SlimeText.text = "King Slime summoned more slime...";
    //}

    #endregion
    

    void PlayerTurnEnd()
    {
        turn += 1f;
        PS.SetState(global::Player.PlayerState.None);
        TextClear();
    }

    public void SlimeTurnEnd()
    {
        turn -= 1f;
        SK.SetState(SlimeKing.SlimeState.None);
        TextClear();
    }

    public void SetState(Turn T)
    {
        if (turnS == T) return;
        turnS = T;
        {
            if (turnS == Turn.player)
            {
                PS.SetState(global::Player.PlayerState.None);
                SK.SetState(SlimeKing.SlimeState.None);
            }
            if (turnS == Turn.boss)
            {
                int roll = Random.Range(1,3);
                if(roll==1) squash();
                else if (roll==2)teleport();
            }
            
        }
    }

    public void TextClear()
    {
        SlimeText.text = "";
        PlayertextObject.SetActive(false);
    }
    

    void Spawn1()
    {
        Instantiate(Mini1);
    } 
    void Spawn2()
    {
        Instantiate(Mini2);
    }
}
