using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class retry : MonoBehaviour
{
    public void OnMouseEnter()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        gameObject.transform.localScale = new Vector3(transform.localScale.x*1.2f,transform.localScale.y*1.2f,transform.localScale.z*1.2f);
    }

    public void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color=Color.gray;
        gameObject.transform.localScale = new Vector3(transform.localScale.x/1.2f,transform.localScale.y/1.2f,transform.localScale.z/1.2f);
    }

    public void OnMouseUpAsButton()
    {
        gameObject.GetComponent<SpriteRenderer>().color=Color.gray;
        gameObject.transform.localScale = new Vector3(transform.localScale.x/1.2f,transform.localScale.y/1.2f,transform.localScale.z/1.2f);
        BTM();
    }
    public void BTM()
    {
        SceneManager.LoadScene(1);
    }
}
