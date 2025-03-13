using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class eventTrigger : MonoBehaviour
{
    public GameObject imageChange;
    public UnityEvent OnTimerHasFinish;

    public void MouseEnterImage()

    {
        imageChange.SetActive(true);
    }

    public void MouseLeftImage()
    {
        imageChange.SetActive(false);

    }

    public void MouseClicksImage()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
