using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEvent : MonoBehaviour
{
   public float teleportTimes = 4f;
   private GameManager GM;
   private NTBHolder NTB;
   public GameObject Counter;
   public Target2 TG;
   private void Start()
   {
      Instantiate(Counter);
      NTB = FindObjectOfType<NTBHolder>();
      GM = FindObjectOfType<GameManager>();
      GM.EventGrey.SetActive(true);
   }
   private void Update()
   {
      TG = FindObjectOfType<Target2>();
      if (teleportTimes <= 0)
      {
         TG.deletethis();
         new WaitForSeconds(1);
         GM.turn=2f;
         GM.EventGrey.SetActive(false);
         NTB.ButtonOn();
         Destroy(gameObject);
      }
   }
}
