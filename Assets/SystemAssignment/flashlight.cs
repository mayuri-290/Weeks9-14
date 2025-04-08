using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class flashlight : MonoBehaviour
{
    public Slider sliderTimer;

    public bool resetTimer = false;

    public Button stopButton;

    // Start is called before the first frame update
    void Start()
    {
        sliderTimer.minValue = 0;
        sliderTimer.maxValue = 3;
        sliderTimer.value = sliderTimer.maxValue;


        StartCoroutine(nightBarRepeating());
    }

    private void Update()
    {
        if (resetTimer)
        {
            StartCoroutine(nightBarRepeating());
        }
    }

    // Update is called once per frame
    IEnumerator nightBarRepeating()
    {
        resetTimer = false;
        float t = 0;

        while (sliderTimer.value > sliderTimer.minValue)
        {
            sliderTimer.value -= Time.deltaTime;
            yield return null;
        }

        while (t < 3)
        {
            t += Time.deltaTime;
            yield return null;
        }

        sliderTimer.value = sliderTimer.maxValue;
        resetTimer = true;
    }
}
