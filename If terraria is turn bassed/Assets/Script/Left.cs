using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;

public class Left : MonoBehaviour
{
    public NoteDown ND;
    public DodgeMiniGame_2 DM;
    public bool inRange = false;
    public GameObject LeftA;
    public GameObject GreatGFX;
    public GameObject MissedGFX;
    public GameObject leftClone;
    
    public void Update()
    { 
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(inRange)
            { 
               
                hit();
            }
            //else
            //{
            //    missed();
           
            //}
        }
        
        
    }

    public void SpawnLeft()
    {
        
         leftClone = Instantiate(LeftA) as GameObject;
        
        
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LeftKey"))
        {
            inRange = true;
            Debug.Log("Inrange");
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("LeftKey"))
        {
           
           // missed();
            inRange = false;

        }
    }
    public void hit()
    {
        GreatGFX.SetActive(true);
        Invoke("HitShow",1f);
        Destroy(leftClone);
        

    }

    public void missed()
    {
       
        DM.FailedTime += 1;
        
        MissedGFX.SetActive(true);
         Invoke("MissedShow",1f);
         Destroy(leftClone);
    }
    public void HitShow()
    {
        GreatGFX.SetActive(false);

    }
    public void MissedShow()
    {
        MissedGFX.SetActive(false);
    }

   
}
