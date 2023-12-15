using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NTBHolder : MonoBehaviour
{
   public GameObject Button;
   
   public void ButtonOn()
   {
      Button.SetActive(true);
   } 
   public void ButtonOff()
   {
      Button.SetActive(false);
   }
}
