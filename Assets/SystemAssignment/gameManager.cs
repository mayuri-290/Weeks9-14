using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public AudioSource hitSound;

    public bool hasWon = false;

    public void PlayHitSound()
    {
        hitSound.Play();
    }

}
