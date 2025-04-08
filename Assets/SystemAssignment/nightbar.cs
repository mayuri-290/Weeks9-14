using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class nightbar : MonoBehaviour
{
    public Slider sliderTimer;
    public float t = 0.5f;
    public TextMeshProUGUI timerText;

    public GameObject loseScene;

    // Start is called before the first frame update
    void Start()
    {
        sliderTimer.minValue = 0;
        sliderTimer.maxValue = 5;
        sliderTimer.value = t;

    }

    // Update is called once per frame
    void Update()
    {
        sliderTimer.value -= Time.deltaTime*0.2f;
        sliderTimer.value = Mathf.Max(sliderTimer.value, 0);

        if(sliderTimer.value<=0)
        {
            loseScene.SetActive(true); 
        }
    }

}


