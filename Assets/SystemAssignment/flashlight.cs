using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class flashlight : MonoBehaviour
{
    public Slider sliderTimer;
    public float t = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        sliderTimer.minValue = 0;
        sliderTimer.maxValue = 3;
        sliderTimer.value = t;
    }

    // Update is called once per frame
    void Update()
    {
        sliderTimer.value -= Time.deltaTime * 0.2f;
        sliderTimer.value = Mathf.Max(sliderTimer.value, 0);
    }
}
