using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public DoorController targetDoor;
    public bool playerStay = false;
    public Canvas canvas;

    private void Update()
    {
        canvas.gameObject.SetActive(playerStay);
        if(playerStay && Input.GetKeyDown(KeyCode.E))
        {
            targetDoor.doorOpen = !targetDoor.doorOpen;
        }

        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerStay = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerStay = false;
        }
    }
}
