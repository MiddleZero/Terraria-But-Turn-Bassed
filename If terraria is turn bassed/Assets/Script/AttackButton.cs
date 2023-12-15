using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttackButton : MonoBehaviour
{
    public GameManager GM;
    public TextMeshProUGUI BT;
    public Animator This;
    private void OnMouseUpAsButton()
    {
        StartCoroutine(Clicked());
    }
    
    private void OnMouseEnter()
    {
       This.Play("Attack_Buttone_Animation_Null");
        BT.GetComponent<TextMeshProUGUI>().color = Color.gray;
    }  
    private void OnMouseExit()
    {
        This.Play("Attack_Buttone_Animation");
        BT.GetComponent<TextMeshProUGUI>().color = Color.white;
    }

    public IEnumerator Clicked()
    {

        This.Play("Attack_Buttone_Animation");
        yield return null;
        GM.MainUI.SetActive(false);
        GM.SlimeText.text = ("Aim for the Boss...");
        GM.Invoke("CLearText", 2f);
        GM.Invoke("Attack", 2f);
        BT.GetComponent<TextMeshProUGUI>().color = Color.white;
    }
}
