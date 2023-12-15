using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthChangeIN : MonoBehaviour
{
   private DamageCounter DMC;
   public TextMeshProUGUI ROUNDTEXT;
   private float Timer=1f;
   public Vector3 DesiredSize = new Vector3(1,1,1);
   public Rigidbody2D RB;

   public void Awake()
   {
      RB = gameObject.GetComponent<Rigidbody2D>();
   }

   public void Start()
   {
      DMC = FindObjectOfType<DamageCounter>();
      ROUNDTEXT.text = ("-") + DMC.DamgeTakenCount;
   }

   public void Update()
   {
      Timer -= Time.deltaTime;
      if (Timer <= 0)
      {
         StartCoroutine(DeleteThis());
      }
   }

   public IEnumerator DeleteThis()
   {
      RB.gravityScale = -1f;
      yield return new WaitForSeconds(1f);
      RB.gravityScale = 1f;
      gameObject.transform.localScale = Vector3.Lerp(transform.localScale,DesiredSize,2f);
      DesiredSize = new Vector3(0, 0, 0);
      yield return new WaitForSeconds(3f);
      Destroy(gameObject);
   }
}
