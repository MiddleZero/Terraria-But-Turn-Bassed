using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt_Player : MonoBehaviour
{
    private PlayerMovement PM;
    public GameObject EYE_Hurt;
    public IEnumerator Hurt()
    {
        yield return null;
        EYE_Hurt.SetActive(true);
        EYE_Hurt.GetComponent<SpriteRenderer>().color = Color.red;
            
        yield return new WaitForSeconds(0.2f);
        EYE_Hurt.GetComponent<SpriteRenderer>().color= Color.white;
        
        yield return new WaitForSeconds(2f);
        EYE_Hurt.SetActive(false);

    }
}
