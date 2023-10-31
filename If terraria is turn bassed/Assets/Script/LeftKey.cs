using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftKey : MonoBehaviour
{
   public DodgeMiniGame_1 DM1;
   public SpriteRenderer ThisO;
   public void OnMouseDown()
   {
      DM1.left();
      Debug.Log("pressed");
      if (DM1.YesOrNo == 1)
      {
         Debug.Log("Dodged");
         DM1.GM.PlayertextObject.SetActive(true);
         DM1.GM.Invoke("SlimeTurnEnd",2f);
         DM1.Invoke("SelfD",2.1f);
      }
      else
      {
         DM1.GM.SK.SetState(SlimeKing.SlimeState.Squash);
         Debug.Log("Failed");
         DM1.GM.Boss.Play("Squish");
         DM1.GM.PS.ArmorPoint -= 10f;
         if (DM1.GM.PS.ArmorPoint <= 0)
         {
            DM1.GM.PS.playrHealth -= 10f;
         }
         DM1.GM.Invoke("SlimeTurnEnd",2f);
         DM1.Invoke("SelfD",2.1f);
      }
   }
   public void OnMouseEnter()
   {
      ThisO.color=Color.gray;
   }
   public void OnMouseExit()
   {
      ThisO.color=Color.white;
   }
}
