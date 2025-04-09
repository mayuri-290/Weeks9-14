using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class chests : MonoBehaviour
{
    public int score = 0;
    //I set this value, to keep track of the player's current score. 
    //I plan to set it to 0 frist, and when the players collect the chest, the points will add. 
    public float touchRange = 1f;
    //The distance between the players and chest to allow collection.
    //if the player is closer than this distance, the chest can be collected. 
    public Sprite openChest;
    //This sprite image shows a chest is already opened. 
    //So, when the player collects the chest, this image will be changed. 
    public Transform playerPos;
    //The player's position in the game world.
    public TextMeshProUGUI scoreText;
    //This is a reference to the UI text that displays the player's score on the screen.
    public GameObject winningScene;
    //The game object that will be shown when the player wins the game.
    public gameManager gameManager;
    // A reference to another script called gameManager.
    // which controls the win condition and other separate effects of the game.

    public List<GameObject> chestList;

    // Start is called before the first frame update
    void Start()
    {
       //---->problem recorded. //chestList = new List<GameObject>(); Problems occurs when adding this initializing list. Because it will reset the condition of chests.

        scoreText.text = " " + score;
        // This code shows the starting score on the screen.

        gameManager.hasWon = false;
        // Make sure the game is not set as won at the beginning.

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < chestList.Count; i++)//The if statement shows each chest in the chestList, one by one.

        {
            GameObject chest = chestList[i];// I get the current chest from the list first.

            //Then I find out how far the player is from the chest.
            //I use Vector2.Distance to measure distance between two positions.
            float distance = Vector2.Distance(playerPos.transform.position, chest.transform.position);

            //If the player is close enough to the chest within the touch range.
            if (distance < touchRange)
            {
                //Get the SpriteRenderer component from the chest.
                //the aim is to control which image the chest shows.
                SpriteRenderer collectedChest = chest.GetComponent<SpriteRenderer>();

                //I check if this chest is still not collected yet.
                //If it is already opened, skip it to avoid adding score again.
                if (collectedChest.sprite != openChest)
                {
                    collectedChest.sprite = openChest;//change the chest's image to "open".

                    score += 1;//Increase the player's score by 1. 
                }
            }
        }

        //I create a winning condition, see if the player has collected 8 chests. 
        if (score>=8)
        {
            gameManager.hasWon = true;
            //I use this code to tell the game manager script that the player has reached the winning condition.
            //I set this condition, so other parts of the game like monsters can check this value and respond to actions like stop some rountines or show winning screen. 
            winningScene.SetActive(true);
            //Make the winning UI or scene appear so the player knows they won.
        }

        scoreText.text = " " + score;
        //This line updates the score text on the screen to show the new score.
    }
}
