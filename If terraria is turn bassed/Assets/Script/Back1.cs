using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back1 : MonoBehaviour
{
    public GameObject ThisButton;
    public GameManager_Menu GMM;
    public Transform This;
    public AudioSource JEA;
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
        JEA.volume = 1f;
        ThisButton.GetComponent<SpriteRenderer>().color=Color.grey;
        GMM.menuState = GameManager_Menu.MenuState.Menu;
        GMM.Play.SetActive(true);
        GMM.Setting.SetActive(true);
        GMM. Quit.SetActive(true);
        GMM.Title.SetActive(true);
        GMM.B1.SetActive(false);
        GMM.KS.Play("Slime_Menu_real");
        GMM.BG.Play("Background2");
        GMM.CF.Play("CliffDown"); 
        This.transform.localScale = new Vector3(transform.localScale.x/1.2f,transform.localScale.y/1.2f,transform.localScale.z/1.2f);
    }
}
