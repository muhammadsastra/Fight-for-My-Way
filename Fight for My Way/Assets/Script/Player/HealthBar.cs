using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image darah;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        darah.color = gradient.Evaluate(1f);
    }
    public void setHealth(int health)
    {
        slider.value = health;
        darah.color = gradient.Evaluate(slider.normalizedValue);
    }
}
