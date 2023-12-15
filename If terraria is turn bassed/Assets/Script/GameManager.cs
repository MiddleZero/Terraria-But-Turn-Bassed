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

    public Animator Black;
    public Player PS;
    public SlimeKing SK;
    
    public TextMeshProUGUI SlimeText;
    public GameObject PlayertextObject;
    public float turn = 1f;
    public Animator PlayerAnim;
    public Animator BossAnim;
    [SerializeField] private Turn turnS;
    public GameObject SquashEvent;
    public GameObject TeleportEvent;
    public GameObject SpawnEvent;
    public GameObject AttackEvent;
    public List<LaneController> Lanes;
    public GameObject EventGrey;
    public TextMeshProUGUI HealthPotionNumber;
    public TextMeshProUGUI IronSkinPotionNumber;
    public GameObject MainUI;
    public GameObject PotionUI;
    public DefendBar DB;
    public DamageCounter DMC;
    public int turns =1;
    public TextMeshProUGUI RoundText;
    public Animator NRI;
    public Transform canvas;
    public GameObject PosBoss;
    public GameObject PosPlayer;
    
    #endregion

   
    public enum Turn
    {
        NoTurn,
        player,
        Boss,
    }
    
    public LaneController GetLane(int lane)
    {
        return Lanes[lane - 1];
    }

    public void Awake()
    {
        Black.Play("Black_Backward");
    }

    public void Update()
    {
        
        DMC = FindObjectOfType<DamageCounter>();
        RoundText.text = ("Round: ") + turns;
        HealthPotionNumber.text = PS.healthPotionNumber.ToString();
        IronSkinPotionNumber.text = PS.IronPotionNumber.ToString();
        if (turn == 1)
        {
            SetState(Turn.player);
        }

        if (turn == 2)
        {
            SetState(Turn.NoTurn);

        }

        if (turn == 3)
        {
            SetState(Turn.Boss);

        }

        if (PS.currentHealth <= 0)
        {
            Invoke("SwitchScene1",0.5f);
        }

        if (SK.currentHealth <= 0)
        {
            Invoke("SwitchScene2",0.5f);
        }
    }

    public void SwitchScene1()
    {
        SceneManager.LoadScene(3);
    } 
    public void SwitchScene2()
    {
        SceneManager.LoadScene(2);
    }
    public void SetState(Turn T)
    {
        if (turnS == T) return;
        turnS = T;
        {
            if (turnS == Turn.player)
            {
                Attack();
            } 
            if (turnS == Turn.NoTurn)
            {
                StartCoroutine(PlayerDM());
            }

            if (turnS == Turn.Boss)
            {
                StartCoroutine(BossDM());
            }

        }
    }

    #region Event

    public void Attack()
    {
        Instantiate(AttackEvent);
    }

    public void squash()
    {
        Instantiate(SquashEvent);
    }

    public void teleport()
    {
        Instantiate(TeleportEvent);
    }

    public void summon()
    {
        Instantiate(SpawnEvent);
    }


    #endregion

    #region UI

    public void PlayerTurn()
    {
        turn = 1f;
    }

    public void BossTurn()
    {
        turn = 3f;
    }
    
    public void potionUI()
    {
        PotionUI.SetActive(true);
        MainUI.SetActive(false);
    }

    public void Heal()
    {
        if (PS.healthPotionNumber >= 1)
        {
            PS.Healing();
            PotionUI.SetActive(false);
            turn = 3f;
        }
    }

    public void Iron()
    {
        if (PS.IronPotionNumber >= 1)
        {
            PS.AddShield();
            PotionUI.SetActive(false);
            turn = 3f;
        }
    }


    #endregion

    void CLearText()
    {
        SlimeText.text = ("");
    }

    void BossAnimation()
    {
        BossAnim.Play("Slime King_Idol");
    }
    void PlayerAnimation()
    {
        PlayerAnim.Play("PlayerIdol");
    }
    IEnumerator BossEvent()
    {
        yield return null;
        int roll = Random.Range(1, 4);
        yield return null;
        if (roll == 1)
        {
            SlimeText.text = "King Slime Used Squash...";
            yield return new WaitForSeconds(2f);
            CLearText();
            squash();
        }
        else if (roll == 2)
        {
            SlimeText.text = "King Slime teleported...";
            yield return new WaitForSeconds(2f);
            CLearText();
            teleport();
        }
        else if (roll == 3)
        {
            SlimeText.text = "King Slime summoned more slime...";
            yield return new WaitForSeconds(2f);
            CLearText();
            summon();
        }
        else if (roll == 4)
        {
        }

    }

    public IEnumerator PlayerDM()
    {
        PS.TakeDamge();
        if (DMC.DamgeTakenCount > 0)
        {
            PS.playerA.Play("Player_Hurt");
            Instantiate(PosPlayer);
           
        }
        else
        {
                    
        }
        yield return null;
        DMC.DamgeTakenCount = 0;
    }

    public IEnumerator BossDM()
    {
        SK.TakeDamge();
        if (DMC.DamgeTakenCount > 0)
        {
            SK.Boss.Play("Slime King_Hurt");
            Instantiate(PosBoss);
            
        }
        else
        {

        }

        yield return null;
        DMC.DamgeTakenCount = 0;
        MainUI.SetActive(false);
        StartCoroutine(BossEvent());

    }






}
