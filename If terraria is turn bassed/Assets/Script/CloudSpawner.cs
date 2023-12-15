using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    public float Timer=2;
    public GameObject Cloud1; 
    public GameObject Cloud2;
    public GameObject Cloud3;
    public GameObject Cloud4;
    public float SpawnValue;
    void Update()
    {
        SpawnValue=Random.Range(1, 5);
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            if (SpawnValue == 1)
            {
                Instantiate(Cloud1).transform.localPosition=gameObject.transform.localPosition;
                Timer = Random.Range(3,7);
            }
            if (SpawnValue == 2)
            {
                Instantiate(Cloud2).transform.localPosition=gameObject.transform.localPosition;
                Timer = Random.Range(3,7);
            }
            if (SpawnValue == 3)
            {
                Instantiate(Cloud3).transform.localPosition=gameObject.transform.localPosition;
                Timer = Random.Range(3,7);
            }
            if (SpawnValue == 4)
            {
                Instantiate(Cloud4).transform.localPosition=gameObject.transform.localPosition;
                Timer = Random.Range(3,7);
            }
            
        }
    }
}
