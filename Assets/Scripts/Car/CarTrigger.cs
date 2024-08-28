using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarTrigger : MonoBehaviour
{
    public TMP_Text carText;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Log character
            Debug.Log("Car trigger engaged");

            // Draw a text box
            carText.text = "Press E to enter car";

        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Log character
            Debug.Log("Car trigger disengaged");

            // Disengage the text box
            carText.text = "";
        }
    }
}
