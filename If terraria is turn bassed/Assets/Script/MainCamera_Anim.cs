using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_Anim : MonoBehaviour
{
    public Animator Main;

    public IEnumerator Shake()
    {
        Main.Play("FightCameraShake");
        yield return new WaitForSeconds(1f);
        Main.Play("FightCamera");
    }
    public IEnumerator Hurt()
    {
        Main.Play("FightCameraHurt");
        yield return new WaitForSeconds(1f);
        Main.Play("FightCamera");
    }
}
