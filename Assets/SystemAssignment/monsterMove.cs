using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

//The aim to create this script is to control the monsters' movements and attack behaviour. 
//When the monster moves towards the player, it reduces the player's health using a Unity event.
//Set a condition: if the player's health reaches zero, losing scene appears. 
public class monsterMove : MonoBehaviour
{
    public float MonsterSpeed = 1f;//set the monster speed. 
    public Transform PlayerPos;//Set a player position, this will be needed in coding the monster chasing. Player position need to be determined. 
    public float touchRange = 1f;//This is a value to calculate the distance for the monster to hit player.

    public Slider healthBar;//A health bar UI shown in unity.

    public UnityEvent playerHit;//This unity event is used for trigger when the player is hit.
                                //It can be used together with listeners, so that functions will be called automatically.
    public GameObject loseScene;//The background of lose scene.

    public gameManager gameManager;//Tells if the player's winning condition.
    
    void Start()
    {
        //Firstly, set min and max value for slider.
        healthBar.minValue = 0;
        healthBar.maxValue = 50;
        healthBar.value = healthBar.maxValue;//Slider value should be full at the beginning. 

        playerHit.AddListener(DecreaseHealth);
        //Add a listener function to the player hit event.
        //When the event is invoked, this function will be called.
    }

    void Update()
    {
        //stop here. Stop the following code moving, make sures losing condition don't pops out.
        if (gameManager.hasWon == true)
        {
            return;
        }

        transform.up = PlayerPos.position - transform.position;//transform up will make sure the monsters face player side.
        transform.position += transform.up * MonsterSpeed * Time.deltaTime;//move monsters forward in player's direction in a smooth speed. 

        float distance = Vector2.Distance(PlayerPos.transform.position, transform.position);//This will calculate the distance between monster and players.

        if (distance < touchRange)//If statement asking: is the player within the attack range?
        {
            playerHit.Invoke();//This triggers the player hit event, when triggers reduce health by -10.
            Destroy(gameObject);//If the monster damaged the player, destroy this monster. 
        }

        Debug.Log("Health Bar Initial Value: " + healthBar.value);//Shows the curretn health value, it is also a way to check if the health bar is working properly when monster touches player. 

    }
    public void DecreaseHealth()//This function is for reducing player's health when they are hit by the monsters. 
    {   
        healthBar.value -= 10;//Health will decrease 10 each hit.

        if(healthBar.value<=0)//Set the if here: if the player's health is less or = to 0, the losing scene will pop out. 
        {
            loseScene.SetActive(true);
        }
    }
 }

