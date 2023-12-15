using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject This;
    public float MovementSpeed = 1f;
    public Rigidbody2D RD;
    public Vector2 MoveInput;
    public bool flip = false;
    private playerState ps;
    public Animator EPA;
    public float IVtime = 2f;
    public GameObject EYE_Hurt;
    [SerializeField] enum playerState
   {
       stay,
       move
   }

    
    void Update()
    {
        if (flip)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            EYE_Hurt.transform.localPosition = new Vector3(-0.00292784f, 0.01829901f, 0.1f);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            EYE_Hurt.transform.localPosition = new Vector3(-0.00292784f, 0.01829901f, -0.05489691f);
        }

        if (MoveInput.x >0f)
        {
            flip = false;
        }
        else if (MoveInput.x <0f)
        {
            flip = true;
        }
        
        if((MoveInput.x == 0f)&&(MoveInput.y == 0f))
        {
            ps = playerState.stay;
        }
        else
        {
            ps = playerState.move;
        }
        
        MoveInput.x = Input.GetAxisRaw("Horizontal");
        MoveInput.y = Input.GetAxisRaw("Vertical");
        
        MoveInput.Normalize();
        RD.velocity = MoveInput * MovementSpeed;

        if (ps == playerState.stay)
        {
            EPA.Play("EventIdol");
        }
        
        if (ps == playerState.move)
        {
            EPA.Play("EventWalk");
        }

      
    }
}
