using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPlayerCollider : MonoBehaviour
{
    public BulletScript BS;
    public Player PS;
    public float InvincibleTime = 0;
    public Hurt_Player HP;
    public DamageCounter DMC;

    public MainCamera_Anim MCA;
   // public GameObject GFX;
    

    private void Start()
    {
        PS = FindObjectOfType<Player>();
    }

    public void Update()
    {
        MCA = FindObjectOfType<MainCamera_Anim>();
        BS = FindObjectOfType<BulletScript>();
        DMC = FindObjectOfType<DamageCounter>();
        InvincibleTime -= Time.deltaTime;
    }

    public void Invinsible()
    {
        InvincibleTime = 1f;
       
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if ((other.CompareTag("Boss"))&&(InvincibleTime<=0))
        {
            DMC.DamgeTakenCount += 15;
            HP.StartCoroutine(HP.Hurt());
            Invinsible();
            MCA.StartCoroutine(MCA.Hurt());
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.CompareTag("SlimeBullets"))&&(InvincibleTime<=0))
        {
            DMC.DamgeTakenCount += 15;
            MCA.StartCoroutine(MCA.Hurt());
            Invinsible();
            StartCoroutine(TriggerBullets());
        }
    }

      IEnumerator TriggerBullets()
    {
        HP.StartCoroutine(HP.Hurt());
        Invinsible();
        yield return null;
        BS.DeleteThis();

    }
}
