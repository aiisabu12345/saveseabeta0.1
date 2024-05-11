using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthslider;

    public void SetSlider(float amount)
    {
        healthslider.value = amount;
    }

    public void SetSliderMax(float amount)
    {
        healthslider.maxValue = amount;
        SetSlider(amount);
    }
}
