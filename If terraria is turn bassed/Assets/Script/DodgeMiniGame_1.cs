using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class DodgeMiniGame_1 : MonoBehaviour
{
    public GameManager GM;
    public float YesOrNo;
    public bool dodged=false;
    public GameObject ThisO;
    public GameObject Hide;

    public void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    


    public void left()
    {
        Hide.SetActive(false);
        YesOrNo =+ UnityEngine.Random.Range(1,3);;
        
    } 
    public void right()
    {
        Hide.SetActive(false);
        YesOrNo =+ UnityEngine.Random.Range(1,5);;
        
    }

    public void SelfD()
    {
        Destroy(ThisO);
    }
   
   
}
