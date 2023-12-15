using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEvent : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private float timer;
    public float bulletHitTime = 6f;
    private NTBHolder NTB;
    private GameManager GM;
    
    private void Start()
    {
        NTB = FindObjectOfType<NTBHolder>();
        GM = FindObjectOfType<GameManager>();
        GM.EventGrey.SetActive(true);
    }
    void Update()
    {
       
        if (bulletHitTime <= 0f)
        {
            Invoke("DeleteThis",1f);
        }
        timer += Time.deltaTime;

        if (timer > 2)
        {
            timer = 0;
            shoot();
        }
    }

    void DeleteThis()
    {
        GM.turn=2f;
        GM.EventGrey.SetActive(false);
        NTB.ButtonOn();
        Destroy(gameObject);
    }
    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity).transform.parent=gameObject.transform;
    }
}
