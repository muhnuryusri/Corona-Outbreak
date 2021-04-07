using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateBar : MonoBehaviour
{
    private Image image;
    public Slider slider;
    public float timeToChange = 0.1f;
    private float timeSinceChange = 0f;
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        timeSinceChange += Time.deltaTime;

        if (image != null && timeSinceChange >= timeToChange)
        {
            Color newColor = new Color(
                    Random.value,
                    Random.value,
                    Random.value
                );
            image.color = newColor;
            timeSinceChange = 0f;
        }
    }

    public void SetMaxUltimate(int ult)
    {
        slider.maxValue = ult;
        slider.value = ult;
    }

    public void SetUltimate(int ult)
    {
        slider.value = ult;
    }
}
