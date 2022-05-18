using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImprovedHealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = 30;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        
        slider.value += health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
