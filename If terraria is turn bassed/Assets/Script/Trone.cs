using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Trone : MonoBehaviour
{
    public Rigidbody2D RB;

    public void Fall()
    {
        RB.gravityScale = 1;
    }
}
