using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class monsterMove : MonoBehaviour
{
    public float MonsterSpeed = 1f;
    public Transform PlayerPos;

    public float touchRange = 1f;


    //public List<GameObject> monstersList;

    public Slider healthBar;

    public UnityEvent playerHit;

    public GameObject loseScene;

    public gameManager gameManager;
    

    // Start is called before the first frame update
    void Start()
    {
        healthBar.minValue = 0;
        healthBar.maxValue = 50;
        healthBar.value = healthBar.maxValue;

    }

    // Update is called once per frame
    void Update()
    {
        //stop here. Stop the following code moving, make sures losing condition don't pops out.
        if (gameManager.hasWon == true)
        {
            return;
        }
         
        transform.up = PlayerPos.position - transform.position;
        transform.position += transform.up * MonsterSpeed * Time.deltaTime;

        //for (int i = 0; i < monstersList.Count; i++)
        //{
            //GameObject monsters = monstersList[i];

            float distance = Vector2.Distance(PlayerPos.transform.position, transform.position);

            if (distance < touchRange)
            {

            playerHit.Invoke();
            Destroy(gameObject);

            }
        Debug.Log("Health Bar Initial Value: " + healthBar.value);

    }
    //}

    public void DecreaseHealth()
    {
        healthBar.value -= 10;

        if(healthBar.value<=0)
        {
            loseScene.SetActive(true);
        }
    }


 }

