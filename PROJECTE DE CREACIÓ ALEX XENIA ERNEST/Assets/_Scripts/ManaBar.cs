using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxShield(int mana)
    {
        slider.maxValue = mana;
        slider.value = 0;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetShield(int mana)
    {
        slider.value += mana;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
