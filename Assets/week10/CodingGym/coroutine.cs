using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using UnityEngine;

public class coroutine : MonoBehaviour
{
    public AnimationCurve grow;
    public float t;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        if (t > 1)
        {
            t = 0;
        }
        transform.localScale = Vector2.one * grow.Evaluate(t);
    }
    public void startGrowing()
    {

    }
}
