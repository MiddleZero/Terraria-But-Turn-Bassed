using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTurnButtonScript : MonoBehaviour
{
   public Animator PB;
   public GameManager GM;

   public void OnMouseEnter()
   {
      
      
   }

   public void OnMouseExit()
   {
      
   }

   public void OnMouseUpAsButton()
   {
      StartCoroutine(Clicked());
   }

   IEnumerator Clicked()
   {
      yield return null;
      GM.NRI.Play("Round_IN_NUll");
      yield return null;
      GM.NRI.Play("Round_IN");
      GM.MainUI.SetActive(true);
      PB.Play("Potion_Button_Null");
      yield return null;
      gameObject.SetActive(false);
      GM.turns += 1;
   }
}
