using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public GameObject Slime;
    public GameObject Particle;
    public Trone T;
    public GameObject D;
    public GameObject button;
    void Start()
    {
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        yield return new WaitForSecondsRealtime(3.3f);
        Slime.SetActive(false);
        yield return null;
        Particle.SetActive(true);
        yield return null;
        T.Fall();
        D.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        D.SetActive(false);
        yield return new WaitForSecondsRealtime(1f);
        button.SetActive(true);
    }
   
   
}
