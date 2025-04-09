using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//In this script, I will code the player movement. 
public class playerMovement : MonoBehaviour
{
    public float speed = 5f;//This value controls how fast the player moves. 

    void Update()
    {
        Vector2 pos = transform.position; //Get the current position of the player. 
        pos.x+=Input.GetAxisRaw("Horizontal")*speed*Time.deltaTime;
        //I use GetAxisRaw to cahnge the X position when pressing Left/Right or Key A,D.
        pos.y += Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        //I use GetAxisRaw to cahnge the Y position when pressing up/down or Key W,S.

        transform.position = pos;
        //Move the player to the new signed position. 
    }
}
