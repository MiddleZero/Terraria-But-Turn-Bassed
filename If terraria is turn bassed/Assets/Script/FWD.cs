using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FWD : MonoBehaviour
{
    public SlimeKing SK;
    public Player PS;
   

   
    void Update()
    {
        if (SK.currentHealth <= 0)
        {
            SK.currentHealth = 0;
            Debug.Log("WIN");
        }
        if (PS.currentHealth <= 0)
        {
            PS.currentHealth = 0;
            Debug.Log("Fail");
        }
    }
}
