using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlimeKing : MonoBehaviour
{
    public float slimeKingDefaultRound = 2f;
    public float slimeKingHealth = 500f;
    public TextMeshProUGUI slimeKingHealthText;
    public Animator Boss;
    public SlimeState slimeState;
    public enum SlimeState
    {
        None,
        Squash,
        teleport,
        spawn
    }
    private void Update()
    {
        slimeKingHealthText.text = slimeKingHealth + "/500".ToString();
    }

    public void SetState(SlimeState SS)
    {
        if (slimeState == SS) return;
        slimeState = SS;
        
        if(slimeState==SlimeState.None)
        {
            Boss.Play("Slime King");
        }
        if(slimeState==SlimeState.teleport)
        {
            Boss.Play("Teleport");
        }
    }
    
    

}
