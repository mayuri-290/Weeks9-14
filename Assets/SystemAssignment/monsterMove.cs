using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterMove : MonoBehaviour
{
    public float MonsterSpeed = 1f;
    public Transform PlayerPos;
    public bool monsterStay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.up = PlayerPos.position - transform.position;
        transform.position += transform.up * MonsterSpeed * Time.deltaTime;


    }
}
