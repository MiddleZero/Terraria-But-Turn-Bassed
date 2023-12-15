using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthPotionButton : MonoBehaviour
{
    public TextMeshProUGUI BT;
    public GameManager GM;
    private void OnMouseUpAsButton()
    {
        GM.Heal();
    }
    private void OnMouseEnter()
    {
       
        BT.GetComponent<TextMeshProUGUI>().color = Color.gray;
    }  
    private void OnMouseExit()
    {
        
        BT.GetComponent<TextMeshProUGUI>().color = Color.white;
    }
}
