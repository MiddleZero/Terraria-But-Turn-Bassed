using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Down : MonoBehaviour
{
    public NoteDown ND;
    public DodgeMiniGame_2 DM;
    public bool inRange = false;
    public GameObject DownA;
    public GameObject GreatGFX;
    public GameObject MissedGFX;
    public GameObject downClone;
   

    
    public void Update()
    {
       
        
        
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(inRange)
            { 
                hit();
            }
           // else
           // {
            //    missed();
           
           // }
        }
       
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DownKey"))
        {
            inRange = true;
        }
    } 
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("DownKey"))
        {
            
          //  missed();
            inRange = false;
        }
    }
   
    public void SpawnDown()
    {
        
        downClone = Instantiate(DownA) as GameObject;
        
    }
    public void hit()
    {
        
        Destroy(downClone);
       
        GreatGFX.SetActive(true);
        Invoke("HitShow",1f);
       
    }

    public void missed()
    {
       
        DM.FailedTime += 1;
       
        MissedGFX.SetActive(true);
        Invoke("MissedShow",1f);
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
