using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaslider;

    public void SetSlider(float amount)
    {
        staminaslider.value = amount;
    }

    public void SetSliderMax(float amount)
    {
        staminaslider.maxValue = amount;
        SetSlider(amount);
    }

}
