using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
public class BulletScript : MonoBehaviour
{
    public SpawnEvent SE;
    private GameObject player;
    private Rigidbody2D rb;
    public GameObject Particle1;
    private float speed;
    private Player PS;
    public DamageCounter DMC;
    public MainCamera_Anim MCA;
    void Start()
    {
        MCA = FindObjectOfType<MainCamera_Anim>();
        DMC = FindObjectOfType<DamageCounter>();
        PS = FindObjectOfType<Player>();
        SE = FindObjectOfType<SpawnEvent>();
        speed = Random.Range(2,5);
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("SpawnEventPlayer");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot);
    }

    public void HitEffect()
    {
        Instantiate(Particle1).transform.position=gameObject.transform.position;
        SE.bulletHitTime -= 1f;
    }

    public void DeleteThis()
    {
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("SpawnEventPlayer"))
        {
            HitEffect();

        }

        if (col.CompareTag("Barrier"))
        {
            MCA.StartCoroutine(MCA.Shake());
            HitEffect();
            DeleteThis();
        }
    }
}
