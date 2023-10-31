using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    
    public float playerDefaultTurn = 1f;
   public float playrHealth = 100f;
   public float ArmorPoint;
   public TextMeshProUGUI PlayerHealthText;   
   public TextMeshProUGUI PlayerDefenceText;
   public float healthPotionNumber = 5;
   public float IronPotionNumber = 1;
   [SerializeField] private PlayerState playerState;
   public Animator playerA;
   public enum PlayerState
   {
       None,
       Melee,
       Bow,
       Drink,
   }
   
   

   public void Update()
   {
       PlayerHealthText.text = playrHealth + "/100".ToString(); 
       PlayerDefenceText.text = ArmorPoint.ToString();
       if (ArmorPoint <= 0)
       {
           ArmorPoint = 0;
       }
   }

   public void SetState(PlayerState PS)
   {
       if(playerState == PS) return;
       playerState = PS;
       if (playerState == PlayerState.None)
       {
           playerA.Play("Player");
       }
       if (playerState == PlayerState.Melee)
       {
           playerA.Play("Melee");
       }
       if (playerState == PlayerState.Bow)
       {
           playerA.Play("Bow");
       }
       if (playerState == PlayerState.Drink)
       {
           playerA.Play("Drink");
       }
   }
}
