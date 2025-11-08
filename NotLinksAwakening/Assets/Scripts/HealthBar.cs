using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Image fillImage;
    [SerializeField] private Gradient colorGradient;
    [SerializeField] private bool useGradient = true;

    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        UpdateColor();
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        UpdateColor();
    }

    void UpdateColor()
    {
        if (useGradient && fillImage != null && colorGradient != null)
        {
            fillImage.color = colorGradient.Evaluate(slider.normalizedValue);
        }
    }
}
