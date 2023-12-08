using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaGauge : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private PlayerStateMachine stateMachine;
    [SerializeField] private Image fill;

    [SerializeField] private Color staminaDefaultColor;
    [SerializeField] private Color staminaLowColor;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out slider);
        slider.maxValue = stateMachine.PlayerMaxStamina;
        slider.value = slider.maxValue;
        fill.color = staminaDefaultColor;
        stateMachine.onChangeStamina += UpdateValue;
    }

    void UpdateValue(float value)
    {
        slider.value = value;

        if(value < slider.maxValue / 3)
        {
            fill.color = staminaLowColor;
        }
        else
        {
            fill.color = staminaDefaultColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
