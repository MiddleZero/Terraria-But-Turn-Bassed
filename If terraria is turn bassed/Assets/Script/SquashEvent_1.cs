using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SquashEvent_1 : MonoBehaviour
{
   public GameObject ThisEvent;
   public GameObject PlayerIcon;
   public Transform PlayerPosition;
   public GameObject SlimeIcon;
   public float SquashTime = 3f;
   public int lane = 1;
   public GameObject slimeAttackPoint1; 
   public GameObject slimeAttackPoint2; 
   public GameObject slimeAttackPoint3;
   public GameObject CurrentAttackPoint;
   public int slimeLane;
   public float slimeAttackTimer = 3f;
   public float slimeAttackDelay = 1.5f;
   public float AttackTime = 4f;
   public Animator SlimeAnimation;
   public GameManager GM;
   public float SlimeLane;
   private NTBHolder NTB;
  


   private void Start()
   {
  
      NTB = FindObjectOfType<NTBHolder>();
      GM = FindObjectOfType<GameManager>();
      GM.EventGrey.SetActive(true);
      lane = 1;
      Setlane(lane);
   }
   
   public void Update()
   {
      slimeAttackTimer -= Time.deltaTime;
      if (slimeAttackTimer <= 0f)
      {
         SlimeTarget();
         Invoke("SlimeAttack",1f);
         slimeAttackTimer = 3f;
      }

      CurrentAttackPoint = GameObject.FindGameObjectWithTag("Target1");
      
      if (slimeLane == 1)
      {
         slimeAttackPoint1.SetActive(true);
         slimeAttackPoint2.SetActive(false);
         slimeAttackPoint3.SetActive(false);
      } 
      if (slimeLane == 2)
      {
         slimeAttackPoint2.SetActive(true);
         slimeAttackPoint1.SetActive(false);
         slimeAttackPoint3.SetActive(false);
      }
      if (slimeLane == 3)
      {
         slimeAttackPoint3.SetActive(true);
         slimeAttackPoint1.SetActive(false);
         slimeAttackPoint2.SetActive(false);
      }
      
      
      if (lane == 1)
      {
         slimeLane = 1;
      }
      if (lane == 4)
      {
         slimeLane = 3;
      }

      if (lane == 2)
      {
         slimeLane = Random.Range(1,2);
      } 
      if (lane == 3)
      {
         slimeLane = Random.Range(2,3);
      }
     
      
      
      if (AttackTime <= 0f)
      {
         Invoke("DeleteThis",2f);
      }
      
      if (Input.GetKeyDown(KeyCode.A))
      {
         lane--;
         if(lane < 1){
            lane = 1;
         }
         Setlane(lane);
      } 
      if (Input.GetKeyDown(KeyCode.D))
      {
         lane++;
         if(lane > 4){
            lane = 4;
         }
         Setlane(lane);
      }
   }
   
   public void SlimeTarget()
   {
      SlimeAnimation.Play("SlimeSquashIdol");
      SlimeIcon.transform.position = CurrentAttackPoint.transform.position + new Vector3(0f, 2f, -6f);
     
   }
   
   public void SlimeAttack()
   {
      SlimeAnimation.Play("SlimeSquash");
      AttackTime -= 1f;
   }

   public void DeleteThis()
   {
      GM.turn=2f;
      GM.EventGrey.SetActive(false);
      NTB.ButtonOn();
      Destroy(gameObject);
   }
   
   
   
   
   
   public void Setlane(int lane)
   {
      //PlayerPosition.transform.position = GM.GetLane(lane).transform.position;
      if (this.lane ==1f)
      {
         PlayerPosition.transform.localPosition =new Vector3(-1.83f, -4.34f, -5.573324f);
        
      }
      else if (this.lane == 2f)
      {
         PlayerPosition.transform.localPosition =new Vector3(-0.18f, -4.34f, -5.573324f);
         
      }
      else if (this.lane == 3f)
      {
         PlayerPosition.transform.localPosition =new Vector3(1.58f, -4.34f, -5.573324f);
         
      }
      else if (this.lane == 4f)
      {
         PlayerPosition.transform.localPosition =new Vector3(3.28f, -4.34f, -5.573324f);
         
      }
   }
}
