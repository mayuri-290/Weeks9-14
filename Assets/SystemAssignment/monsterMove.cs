using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterMove : MonoBehaviour
{
    public float MonsterSpeed = 1f;

    public Transform PlayerPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = PlayerPos.position - transform.position;
        transform.position += transform.up * MonsterSpeed * Time.deltaTime;

        //Vector2 screenPos = Camera.main.WorldToScreenPoint(pos);

        //if(screenPos.x<0 || screenPos.x>Screen.width)
        {
            
        }

        //if (screenPos.y < 0 || screenPos.y > Screen.height)
        {
            
        }

        //transform.position = pos;

    }
}
