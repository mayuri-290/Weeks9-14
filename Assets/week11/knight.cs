using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knight : MonoBehaviour
{
    SpriteRenderer sr;
    Animator animator;
    public float speed = 2;
    public bool canRun = true;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal"); //make sure the H is capital written. 

        sr.flipX = (direction < 0);
        animator.SetFloat("movement", Mathf.Abs(direction));

        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
            canRun = false;
        }

        if(canRun == true)
        {
            transform.position += transform.right * direction * speed * Time.deltaTime;
        }
    }
    public void AttackHasFinished()
    {
        Debug.Log("The animation just finished!");
        canRun = true;
    }
}
