using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The aim I create this script is to manage important part of the game.
//Like checking if the player has won and playing sound effects when the player is hit by a monster.
//This also helps keep the game logic organized in one place, for example also in Unity, I can drag all the objects in the inspector. 

public class gameManager : MonoBehaviour
{
    AudioSource audioSource;//I ass a audio component that will play sounds.
    public AudioClip hitSound;//This variable is for determine if the monster hit the player, hit sound will play. 

    monsterMove myMonsterMove;//This is a reference to the monsterMove script so I can access its UnityEvent. 

    public bool hasWon = false;//I use this variable to keep track of whether the player has won the game.

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //First, get the AudioSource component attached to this GameObject.
        //The aim is to activate play sounds.
        myMonsterMove.playerHit.AddListener(PlayHitSound);
    }

    public void PlayHitSound() //A function is called here, when the player hits the monster.
    {
        audioSource.PlayOneShot(hitSound);//It will play the audio Source when gets hit. 
    }

}
