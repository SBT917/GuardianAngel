using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaGauge : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private PlayerStateMachine stateMachine;

    // Start is called before the first frame update
    void Awake()
    {
        TryGetComponent(out slider);
        slider.maxValue = stateMachine.PlayerMaxStamina;
        slider.value = slider.maxValue;
        stateMachine.onChangeStamina += UpdateValue;
    }

    void UpdateValue(float value)
    {
        slider.value = value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
