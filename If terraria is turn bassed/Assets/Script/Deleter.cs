using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deleter : MonoBehaviour
{
    public Left L;
    public Right R;
    public Up U;
    public Down D;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LeftKey"))
        {
           Debug.Log(L);
           L.missed(); 
        }
        if (other.CompareTag("RightKey"))
        {
           Debug.Log(R);
           R.missed(); 
        }
        if (other.CompareTag("DownKey"))
        {
           Debug.Log(D);
           D.missed(); 
        }
        if (other.CompareTag("UpKey"))
        {
           Debug.Log(U);
           U.missed(); 
        }
    }
}
