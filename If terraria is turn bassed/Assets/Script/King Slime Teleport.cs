using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSlimeTeleport : MonoBehaviour
{
    public TeleportEvent TE;
    public Target2 TG2;
    public GameObject CurrentTarget;
    public GameObject TargetType2;
    public float Timer=2f;
    public GameObject Player;
    public Animator KINGSLIME;
    public Animation KINGSLIME_Teleport;
    public MainCamera_Anim MCA;
    private void Start()
    {
        MCA = FindObjectOfType<MainCamera_Anim>();
        Player = GameObject.FindGameObjectWithTag("SpawnEventPlayer");
    }

    void Update()
    {
        CurrentTarget = GameObject.FindGameObjectWithTag("Target2");
        TG2 = FindObjectOfType<Target2>();
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            StartCoroutine(TeleportDelay());
            Timer = 2.5f;
        }
    }

    void Warning()
    {
        Instantiate(TargetType2).transform.position=Player.transform.position;
    }

    void Teleport()
    {
        gameObject.transform.position = CurrentTarget.transform.position;
        MCA.StartCoroutine(MCA.Shake());
    }

    IEnumerator TeleportDelay()
    {
        Warning();
        yield return null;

        
        
        KINGSLIME.Play("Slime King_Teleport");
        yield return new WaitForSeconds(1f);
        
        TG2.deletethis();
        Teleport();
        yield return null;
        
       
        
        KINGSLIME.Play("Slime King_Teleport_Reverse");
        yield return new WaitForSeconds(1.5f);
        
        TE.teleportTimes -= 1f;
    }
}
