using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDown : MonoBehaviour
{
    public GameObject ThisO;
    public DodgeMiniGame_2 DM2;
    
    void Update()
    {
        transform.position = transform.position + new Vector3(0,-0.023f, 0);
        
    }

    
}
