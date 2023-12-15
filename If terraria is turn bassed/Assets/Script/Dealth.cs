using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealth : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(Death());
    }

   
    public GameObject H;
    public GameObject L;
    public GameObject R;
    public GameObject B;
    public Rigidbody2D R1;
    public Rigidbody2D R2;
    public Rigidbody2D R3;
    public Rigidbody2D R4;
    public GameObject T;
    public GameObject Buttons;


    public IEnumerator Death()
    {
        yield return new WaitForSeconds(2.5f);
        H.GetComponent<SpriteRenderer>().color=Color.red;
        R1.AddForce(Vector2.up*7, ForceMode2D.Impulse);
        R2.AddForce(Vector2.left*6, ForceMode2D.Impulse);
        R3.AddForce(Vector2.right*6, ForceMode2D.Impulse);
        L.GetComponent<SpriteRenderer>().color=Color.red; 
        R.GetComponent<SpriteRenderer>().color=Color.red;
        B.GetComponent<SpriteRenderer>().color=Color.red;
        R1.gravityScale = 1;
        yield return null;
        R2.gravityScale = 1;
        yield return null;
        R3.gravityScale = 1;
        yield return null;
        R4.gravityScale = 1;
        yield return new WaitForSeconds(2f);
        T.SetActive(true);
        yield return new WaitForSeconds(1f);
        Buttons.SetActive(true);
    }
}
