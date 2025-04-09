using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//I created this script to controls countdowm timer shown as a slider.
//When the timer reaches 0 and the player didn't collect all the chest, the lose scene will appear.
//The aim to create this bar is to give pressure to player. 

public class nightbar : MonoBehaviour
{
    public Slider sliderTimer;//UI slider that shows the countdown.
    public float t = 0.5f;//Set the start value of timer. 
    public TextMeshProUGUI timerText; //This shows the remaining time input.

    public GameObject loseScene;//This will show the lose scene when player ran out of health. I can drag the lose gameobject in unity inspector.

    public gameManager gameManager;//A reference to game manager, to check conditions.

    void Start()
    {
        //First, set the min and max value for the slider.
        sliderTimer.minValue = 0;
        sliderTimer.maxValue = 5;
        sliderTimer.value = t;

    }
    void Update()
    {
        if (gameManager.hasWon == true)
        //Set the stop condition here: I want that when the player won the game, the following action should stop.
        //so that the lose scene will not pop out and cover the winning scene.
        {
            return;
        }

        sliderTimer.value -= Time.deltaTime*0.2f;//use delta time to make the timer reduce slowly.
        sliderTimer.value = Mathf.Max(sliderTimer.value, 0);//this make sures the timer value don't go below 0.

        if(sliderTimer.value<=0) //Set an if statement: if the timer reaches 0, player didn't collect enough chest, the lose scene pops out.
        {
            loseScene.SetActive(true); //Set active makes the losing scene appear.
        }
    }
}


