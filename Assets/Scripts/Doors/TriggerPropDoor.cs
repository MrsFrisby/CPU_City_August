//https://www.youtube.com/watch?v=tJiO4cvsHAo
//SpeedTutor
//Opening a Door in Unity on Trigger Event


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Taken from the tutorial:How To Open Doors Easily in Unity With Trigger Events by Fist Full Of Shrimp

public class TriggerPropDoor : MonoBehaviour
{
    

    [SerializeField] private Animator doorAnimator = null;

    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if(other.CompareTag("Player"))
        {

            if (openTrigger)
            {
                doorAnimator.Play("PropDoorOpening", 0, 0.0f);
                gameObject.SetActive(false);
            }

            else if (closeTrigger)
            {
                doorAnimator.Play("PropDoorClosing", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }

   
}
