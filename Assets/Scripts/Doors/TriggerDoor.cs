﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Taken from the tutorial:How To Open Doors Easily in Unity With Trigger Events by Fist Full Of Shrimp

public class TriggerDoor : MonoBehaviour
{
    private Animator _doorAnimator;

    [SerializeField]
    private int missionID;

    // Start is called before the first frame update
    void Start()
    {
        _doorAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if(other.CompareTag("Player") && GameManager.Instance.currentQuestIndex == missionID)
        {
            // Trigger the door to open
            _doorAnimator.SetTrigger("Open");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player") && GameManager.Instance.currentQuestIndex == missionID)
        {
            // Trigger the door to close
            _doorAnimator.SetTrigger("Closed");
        }
    }
}
