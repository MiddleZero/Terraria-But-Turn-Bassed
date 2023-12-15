using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KingSlimeStart : MonoBehaviour
{
    public Animator Black;
    public GameObject ThisButton;
    public Transform This;
    public BGMCODE bgmc;
    public AudioSource BGM;
    //public GameObject fight;

    public void OnMouseEnter()
    {
        ThisButton.GetComponent<SpriteRenderer>().color = Color.gray;
       // This.transform.localScale = new Vector3(transform.localScale.x*1.2f,transform.localScale.y*1.2f,transform.localScale.z*1.2f);
    }

    public void OnMouseExit()
    {
        
        ThisButton.GetComponent<SpriteRenderer>().color=Color.white;
        //This.transform.localScale = new Vector3(transform.localScale.x/1.2f,transform.localScale.y/1.2f,transform.localScale.z/1.2f);
    }
    public void OnMouseUpAsButton()
    {
        
        StartCoroutine(GameBegin());
        bgmc.StartCoroutine(bgmc.Fade());
    }

    public IEnumerator GameBegin()
    {
        Black.Play("Black_Forward");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }
}
