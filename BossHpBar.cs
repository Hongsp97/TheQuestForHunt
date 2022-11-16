using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Invector;

public class BossHpBar : MonoBehaviour
{
    public vHealthController DragonHealth;
    public Slider slider;

    void Start()
    {
        slider.maxValue = DragonHealth.maxHealth;
        slider.minValue = 0;
    }

    void Update()
    {
        slider.value = DragonHealth.currentHealth;
    }
}
