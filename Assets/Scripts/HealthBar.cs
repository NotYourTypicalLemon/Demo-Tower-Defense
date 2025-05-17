using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient sliderGradient;
    public Image fill;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;  
        slider.value = health;  

        fill.color = sliderGradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider.value = health;

        fill.color = sliderGradient.Evaluate(slider.normalizedValue);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
