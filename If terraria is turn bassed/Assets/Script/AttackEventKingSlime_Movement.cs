using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class AttackEventKingSlime_Movement : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float range;
    [SerializeField]private float maxDistance;

    private Vector2 wayPoint;
    void Start()
    {
        SetNewDestination();
    }

   
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoint) < range)
        {
            SetNewDestination();
        }
    }

    void SetNewDestination()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance,maxDistance),Random.Range(-maxDistance, maxDistance));
    }
}
