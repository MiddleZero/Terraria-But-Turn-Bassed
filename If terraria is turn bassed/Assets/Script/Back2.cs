using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back2 : MonoBehaviour
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
        ThisButton.GetComponent<SpriteRenderer>().color=Color.grey;
        GMM.menuState = GameManager_Menu.MenuState.Menu;
        GMM.B2.SetActive(false);
        GMM.resolution.SetActive(false);
        GMM.Play.SetActive(true);
        GMM.Setting.SetActive(true);
        GMM.Quit.SetActive(true);
        GMM.Title.SetActive(true);
        GMM.MS.Play("Menu_Setting_close");
        This.transform.localScale = new Vector3(transform.localScale.x/1.2f,transform.localScale.y/1.2f,transform.localScale.z/1.2f);
    }
}
