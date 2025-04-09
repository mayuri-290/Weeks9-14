using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//The aim of this script is to create a repeating flashlight effect.
//It will simulate the flashlight charge.
//When the timer runs out, the flashlight will light the screen, and players can get the chests.
//Players need to wait for 3 secs and the falshlight will resets. 

public class flashlight : MonoBehaviour
{
    public Slider sliderTimer;//UI slider shows the flashlight countdown.

    public bool resetTimer = false;//This line tells the script whether to reset and restart the timer again.

    public GameObject background;
    //I create a background to cover and simulate the darkness.
    //When active, the scene looks dark; when inactive, it looks bright.

    void Start()
    {
        //As usual, first set min and max value for the slider.
        sliderTimer.minValue = 0;
        sliderTimer.maxValue = 3;
        sliderTimer.value = sliderTimer.maxValue;//start the slider with full charge.


        StartCoroutine(nightBarRepeating());
        //Use coroutine herer: start the coroutine to begin the flashlight countdown and reset cycle.
    }

    private void Update()
    {
        if (resetTimer)//If the reset timer is true, it means we need to restart the countdown.

        {
            StartCoroutine(nightBarRepeating());//satrt the coroutine and restart the cycle.
            background.SetActive(true);//make the backgournd dark again when flashlight is turned off. 
        }

    }

    IEnumerator nightBarRepeating() //runs the full flashlight cycle:countdown the timer, turnoff the darkness, wait for several secs, restart again.
    {
        resetTimer = false;//I reset timer to false so it don't run this again until it's ready.
        float t = 0;//This is a simple value of timer used for delay. 

        while (sliderTimer.value > sliderTimer.minValue)//Countdown the slider value until it reaches the minimum value.
        {
            sliderTimer.value -= Time.deltaTime;//reduce the slider over time slowly.
            yield return null;//wait for the next frame.
        }

        background.SetActive(false);//when the countdown finishes, turn off the darkness.
        while (t < 3)//wait for 3 secs and starts the flashlight again. 
        {
            t += Time.deltaTime;
            yield return null;
        }

        
        sliderTimer.value = sliderTimer.maxValue;//reset the slider to full again. 
        resetTimer = true;//set the condition to true, so the it loops from update again. 
    }
}
