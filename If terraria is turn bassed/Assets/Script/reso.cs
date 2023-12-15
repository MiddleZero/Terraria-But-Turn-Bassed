using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reso : MonoBehaviour
{
    public GameObject ThisButton;
    public GameManager_Menu GMM;
    public void Start()
    {
        ThisButton.GetComponent<SpriteRenderer>().color = Color.gray;
        gameObject.transform.localScale = new Vector3(transform.localScale.x*1.2f,transform.localScale.y*1.2f,transform.localScale.z*1.2f);
    }
    
    public void OnMouseExit()
    {
        ThisButton.GetComponent<SpriteRenderer>().color=Color.gray;
        gameObject.transform.localScale = new Vector3(transform.localScale.x/1.2f,transform.localScale.y/1.2f,transform.localScale.z/1.2f);
    }
}
