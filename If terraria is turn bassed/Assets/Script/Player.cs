using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
   public int currentHealth;
   public HealthBarScript HB;
   public int playerHealth = 100;
   public int ArmorPoint = 0;
   public TextMeshProUGUI PlayerHealthText;   
   public TextMeshProUGUI PlayerDefenceText;
   public float healthPotionNumber = 5;
   public float IronPotionNumber = 1;
   //[SerializeField] private PlayerState playerState;
   public Animator playerA;
   public GameManager GM;
   public DefendBarSlider AB;
   public int currentShield;
   public DamageCounter DMC;
   // public enum PlayerState
 //  {
   //    None,
  //     Melee,
   //    Bow,
  //     Drink,
  // }


   public void Start()
   {
  
    HB.SetMaxHealth(playerHealth);
    AB.SetArmor(ArmorPoint);
   }

   public void Update()
   {
    
    currentHealth = playerHealth;
    currentShield = ArmorPoint;
    
    DMC = FindObjectOfType<DamageCounter>();
       PlayerHealthText.text = currentHealth + "/100".ToString(); 
       PlayerDefenceText.text = ArmorPoint.ToString();
       if (ArmorPoint <= 0)
       {
           ArmorPoint = 0;
       }

       if (playerHealth <= 0)
       {
        playerHealth = 0;
       }
   }

 
   public void TakeDamge()
   {
    StartCoroutine(Hurt());
    GM.Invoke("PlayerAnimation",1f);
        
   }

   public void Healing()
   {
    playerHealth += 30;
    healthPotionNumber -= 1;
    HB.SetHealth(playerHealth);
   }
   public void AddShield()
   {
    ArmorPoint += 50;
    IronPotionNumber -= 1;
    AB.SetArmor(ArmorPoint);
   }

   public IEnumerator Hurt()
   { if (ArmorPoint > 0)
    {
     ArmorPoint -= DMC.DamgeTakenCount;
     yield return null;
     AB.SetArmor(ArmorPoint);
    }
    else if (ArmorPoint <= 0)
    {
     playerHealth -= DMC.DamgeTakenCount;
     yield return null;
     HB.SetHealth(playerHealth);
    }
   
   }
}
