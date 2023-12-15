using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackEvent : MonoBehaviour
{
    public GameObject Tutorial3;
    public float hits=3f;
    private GameManager GM;
    public SlimeKing SK;

    public void Awake()
    {
        Tutorial3 = GameObject.FindGameObjectWithTag("3");
    }

    private void Start()
    {
        
       
        SK = FindObjectOfType<SlimeKing>();
        GM = FindObjectOfType<GameManager>();
        GM.EventGrey.SetActive(true);
    }

    void Update()
    {
       
        if (hits <= 0)
        {
            Invoke("deleteThis",2f);
           
        }
    }

    void deleteThis()
    {
       
        GM.BossTurn();
        GM.EventGrey.SetActive(false);
        Destroy(gameObject);
    }
}
