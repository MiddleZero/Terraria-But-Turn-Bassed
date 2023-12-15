using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
  public GameObject particle;
  public Rigidbody2D RB;
  private bool hashit;
  [SerializeField]private AttackEvent AE;
  private SlimeKing SK;
  public GameObject KingSlime;
  public GameObject Barrier;
  public DamageCounter DMC;
  private void Start()
  {
    DMC = FindObjectOfType<DamageCounter>();
    KingSlime = GameObject.FindGameObjectWithTag("Boss"); 
    Barrier = GameObject.FindGameObjectWithTag("Barrier");
    RB.GetComponent<Rigidbody2D>();
    SK = FindObjectOfType<SlimeKing>();
  }

  private void Update()
  {
    AE = FindObjectOfType<AttackEvent>();
    if (hashit == false)
    {
      float angle = Mathf.Atan2(RB.velocity.y, RB.velocity.x) * Mathf.Rad2Deg;
      transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
    }
   
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    AE.hits -=1f;
    if (other.gameObject.CompareTag("Boss"))
    {
      transform.parent = KingSlime.transform;
      Instantiate(particle).transform.position=gameObject.transform.position;
      DMC.DamgeTakenCount += 30;
      gameObject.GetComponent<ArrowScript>().enabled = false;
      gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    else
    {
      transform.parent = Barrier.transform;
    }
    hashit = true;
    RB.velocity = Vector2.zero;
    RB.isKinematic = true;
    
    
  }
}
