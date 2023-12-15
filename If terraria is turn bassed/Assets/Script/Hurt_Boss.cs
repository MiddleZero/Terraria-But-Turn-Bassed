using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt_Boss : MonoBehaviour
{
    public GameObject GFX;
   public void OnCollisionEnter2D(Collision2D col)
   {
      if (col.gameObject.CompareTag("Arrow"))
      {
          StartCoroutine(Hurt());
      }
   }
     IEnumerator Hurt()
    {
        yield return null;
      GFX.GetComponent<SpriteRenderer>().color = Color.red;
      yield return new WaitForSeconds(0.2f);
      GFX.GetComponent<SpriteRenderer>().color= Color.white;

     }
}
