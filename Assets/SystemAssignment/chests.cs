using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class chests : MonoBehaviour
{
    public int score = 0;
    public float touchRange = 1f;
    public Sprite openChest;
    public Transform playerPos;
    public TextMeshProUGUI scoreText;


    public List<GameObject> chestList;

    // Start is called before the first frame update
    void Start()
    {
        //chestList = new List<GameObject>(); Problems occurs when adding this initializing list. Because it will reset the condition of chests.

        scoreText.text = " " + score;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < chestList.Count; i++)
        {
            GameObject chest = chestList[i];

            float distance = Vector2.Distance(playerPos.transform.position, chest.transform.position);

            if (distance < touchRange)
            {
                SpriteRenderer collectedChest = chest.GetComponent<SpriteRenderer>();

                if (collectedChest.sprite != openChest)
                {
                    collectedChest.sprite = openChest;

                    score += 1;

                    Debug.Log("Collected a chest!");
                }
            }
        }

        scoreText.text = " " + score;

    }
}


