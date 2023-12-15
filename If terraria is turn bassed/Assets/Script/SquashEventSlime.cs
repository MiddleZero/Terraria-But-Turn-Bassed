using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquashEventSlime : MonoBehaviour
{
    public Transform SLimeKIng;
    public GameObject Particle;
    public MainCamera_Anim MCA;

    public void Update()
    {
        MCA = FindObjectOfType<MainCamera_Anim>();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Target_Particle"))
        {
            Instantiate(Particle).transform.position=SLimeKIng.position;
            MCA.StartCoroutine(MCA.Shake());
        }
    }
}
