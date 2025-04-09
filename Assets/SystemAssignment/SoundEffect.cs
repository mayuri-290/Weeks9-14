using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource hitSound;

    public void PlayHitSound()
    {
        hitSound.Play();
    }
}
