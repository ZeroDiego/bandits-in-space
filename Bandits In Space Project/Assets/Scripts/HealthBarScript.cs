using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {

    public Slider slider;
    [SerializeField] private Text nameText;
    [SerializeField] private Text healthText;

    public void SetMaxHealth (int health) 
    {
        slider.maxValue = health;
        slider.value = health;
        SetHealthText();
    }

    public void SetHealth (int health) 
    {
        slider.value = health;
        SetHealthText();
    }

    public void SetNameText (string name)
    {
        nameText.text = name;
    }

    private void SetHealthText()
    {
        healthText.text = slider.value + "/" + slider.maxValue;
    }
}