using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Up : MonoBehaviour
{
    public NoteDown ND;
    public DodgeMiniGame_2 DM;
    public bool inRange = false;
    public GameObject UpA;
    public GameObject GreatGFX;
    public GameObject MissedGFX;
    public GameObject upClone;
    

    public void Update()
    {
        
        
        
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(inRange)
            { 
               
                hit();
            }
          //  else
           // {
            //   missed();
           
           // }
        }
        
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
        if (other.CompareTag("UpKey"))
        {
            inRange = true;
            Debug.Log("Inrange");
        }
        
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("UNTrigger");
        if (other.CompareTag("UpKey"))
        {
           
           // missed();
            inRange = false;
        }
    }
   
    public void SpawnUp()
    {
        upClone = Instantiate(UpA) as GameObject;
        
    }

    public void hit()
    {
        
        Destroy(upClone);
       
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
