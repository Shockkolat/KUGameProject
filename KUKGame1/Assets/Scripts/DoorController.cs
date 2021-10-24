using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool doorOpen = false;
    Animator doorAnimator;

    private void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    void Update()
    {
            doorAnimator.SetBool("DoorOpen",doorOpen);
    }
}
