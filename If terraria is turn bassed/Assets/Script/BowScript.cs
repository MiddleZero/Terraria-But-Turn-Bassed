using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading;
using TMPro;
using UnityEngine;

public class BowScript : MonoBehaviour
{
    public float arrowNumber = 3f;
    public GameObject arrow;
    public float speed;
    public Transform shotPoint;
    public float Timer1 =0f;
    [SerializeField] private TextMeshProUGUI AmmoText;
    void Update()
    {
        AmmoText.text = arrowNumber.ToString(); 
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        transform.right = direction;
        Timer1 -= Time.deltaTime;
        if ((Input.GetMouseButtonDown(0))&&(Timer1<=0))
        {
            if (arrowNumber > 0f)
            {
                Timer1 = 1f;
                shoot();
                
            }

           
        }
    }

   
    void shoot()
    {
        
        arrowNumber -= 1f;
        GameObject newArrow= Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

   
}
