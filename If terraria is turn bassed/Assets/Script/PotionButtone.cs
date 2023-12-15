using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PotionButtone : MonoBehaviour
{
    public GameManager GM;
    public Animator PB;
    public TextMeshProUGUI BT;
    private void OnMouseEnter()
    {
       PB.Play("Potion_Button");
       BT.GetComponent<TextMeshProUGUI>().color = Color.gray;
    }  
    private void OnMouseExit()
    {
        PB.Play("Potion_Button_Null");
        BT.GetComponent<TextMeshProUGUI>().color = Color.white;
    }

    private void OnMouseUpAsButton()
    {
        BT.GetComponent<TextMeshProUGUI>().color = Color.white;
        PB.Play("Potion_Button_Null");
        GM.potionUI();
    }
}
