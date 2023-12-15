using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : MonoBehaviour
{
  public GameObject ThisButton;
  public Transform This;
  public GameManager_Menu GMM;
  public float DesireSize = 1;
  public float StartSize = 1;
  public AudioSource JEA;

  public void Start()
  {
   // StartSize = transform.localScale.x;
    ThisButton.GetComponent<SpriteRenderer>().color = Color.gray;
  }
  public void Update()
  {
   // transform.localScale = new Vector3(DesireSize, DesireSize, 1);
    if (GMM.reset)
    {
      
    }
  }

  public void OnMouseEnter()
  {
    ThisButton.GetComponent<SpriteRenderer>().color = Color.yellow;
    //DesireSize = 1.2f;
    This.transform.localScale = new Vector3(transform.localScale.x*1.2f,transform.localScale.y*1.2f,transform.localScale.z*1.2f);
  }

  public void OnMouseExit()
  {
    ThisButton.GetComponent<SpriteRenderer>().color=Color.gray;
    This.transform.localScale = new Vector3(transform.localScale.x/1.2f,transform.localScale.y/1.2f,transform.localScale.z/1.2f);
  }

  public void OnMouseUpAsButton()
  {
    JEA.volume = 0.5f;
    GMM.menuState = GameManager_Menu.MenuState.Play;
    ThisButton.GetComponent<SpriteRenderer>().color=Color.gray;
    This.transform.localScale = new Vector3(transform.localScale.x/1.2f,transform.localScale.y/1.2f,transform.localScale.z/1.2f);
  }
}
