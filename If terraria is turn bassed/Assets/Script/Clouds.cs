using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Clouds : MonoBehaviour
{
   public Rigidbody2D RB;

   public void Update()
   {
      RB.velocity = new Vector2(Random.Range(0.5f,1), 0);
   }
}
