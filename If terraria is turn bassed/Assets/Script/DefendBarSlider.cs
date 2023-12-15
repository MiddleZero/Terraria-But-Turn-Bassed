using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefendBarSlider : MonoBehaviour
{
    public Slider slider;

   
    public void SetArmor(int Armor)
    {
        slider.value = Armor;
    }
}
