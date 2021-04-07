using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponBar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxWeapon(int weapon)
    {
        slider.maxValue = weapon;
        slider.value = weapon;
    }

    public void SetWeapon(int weapon)
    {
        slider.value = weapon;
    }
}
