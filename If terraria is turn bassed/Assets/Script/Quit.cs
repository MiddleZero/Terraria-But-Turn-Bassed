using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public GameObject ThisButton;
    public GameManager_Menu GMM;
    public Transform This;
    public void Start()
    {
        ThisButton.GetComponent<SpriteRenderer>().color = Color.gray;
    }
    public void OnMouseEnter()
    {
        ThisButton.GetComponent<SpriteRenderer>().color=Color.yellow;
        This.transform.localScale = new Vector3(transform.localScale.x*1.2f,transform.localScale.y*1.2f,transform.localScale.z*1.2f);
    }

    public void OnMouseExit()
    {
        ThisButton.GetComponent<SpriteRenderer>().color=Color.grey;
        This.transform.localScale = new Vector3(transform.localScale.x/1.2f,transform.localScale.y/1.2f,transform.localScale.z/1.2f);
    }
    public void OnMouseUpAsButton()
    {
        GMM.menuState = GameManager_Menu.MenuState.Quit;
        ThisButton.GetComponent<SpriteRenderer>().color=Color.grey;
        This.transform.localScale = new Vector3(transform.localScale.x/1.2f,transform.localScale.y/1.2f,transform.localScale.z/1.2f);
    }
}
