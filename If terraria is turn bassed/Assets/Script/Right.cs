using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Right : MonoBehaviour
{
    public NoteDown ND;
    public DodgeMiniGame_2 DM;
    public bool inRange = false;
    public GameObject RightA;
    public GameObject GreatGFX;
    public GameObject MissedGFX;
    public GameObject rightClone;
    
    public void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
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
        if (other.CompareTag("RightKey"))
        {
            inRange = true;
            Debug.Log("Inrange");
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("RightKey"))
        {
           
           // missed();
            inRange = false;
        }
    }
   
    public void SpawnRight()
    {
        rightClone = Instantiate(RightA) as GameObject;
        
    }
    public void hit()
    {
       
        Destroy(rightClone);
      
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
