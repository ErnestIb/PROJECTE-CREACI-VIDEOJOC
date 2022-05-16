using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    public Gradient ColorGradient;
    public Image FillArea;

    private HealthSystem health;

    void Awake()
    {
        health = GetComponentInParent<HealthSystem>();
    }

    private void OnEnable()
    {
        health.OnHit += SetValue;
    }

    private void OnDisable()
    {
        health.OnHit -= SetValue;
    }

    void Start()
    {
        slider = GetComponent<Slider>();
        SetValue(1);
    }

    private void SetValue(float f)
    {
        slider.value = f;
        FillArea.color = ColorGradient.Evaluate(f);
    }
}
