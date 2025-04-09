using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip hitSound;

    monsterMove myMonsterMove;

    public bool hasWon = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        myMonsterMove.playerHit.AddListener(PlayHitSound);
    }

    public void PlayHitSound()
    {
        audioSource.PlayOneShot(hitSound);
    }

}
