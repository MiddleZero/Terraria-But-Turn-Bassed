using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BGMCODE : MonoBehaviour
{
 public AudioSource BGM;

 public void Start()
 {
  BGM = GetComponent<AudioSource>();
 }

 public IEnumerator Fade()
 {
  BGM.volume=Mathf.Lerp(0,1,0.1f/2);
  yield return null;
 }
}
