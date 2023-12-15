using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlimeKing : MonoBehaviour
{
 public GameManager GM;
    public float slimeKingDefaultRound = 2f;
    public int currentHealth;
    public int slimeKingHealth = 500;
    public TextMeshProUGUI slimeKingHealthText;
    public Animator Boss;
   // public SlimeState slimeState;
    public HealthBarScript HB;

    private DamageCounter DMC;
    //public enum SlimeState
   // {
    //    None,
    //    Squash,
     //   teleport,
     //   spawn
   // }
    public void Start()
    {
        currentHealth = slimeKingHealth;
       HB.SetMaxHealth(slimeKingHealth);
    }

    private void Update()
    {
     DMC = FindObjectOfType<DamageCounter>();
        slimeKingHealthText.text = currentHealth + "/500".ToString();
    }

    public void TakeDamge()
    {
        currentHealth -= DMC.DamgeTakenCount;
        HB.SetHealth(currentHealth);
        
        GM.Invoke("BossAnimation",1f);
        
    }
    //public void SetState(SlimeState SS)
    //{
      //  if (slimeState == SS) return;
       // slimeState = SS;
        
       // if(slimeState==SlimeState.None)
       // {
       //     Boss.Play("Slime King");
        //}
       // if(slimeState==SlimeState.teleport)
       // {
        //    Boss.Play("Teleport");
       // }
   // }
    
    

}
