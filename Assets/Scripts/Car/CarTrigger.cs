using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarTrigger : MonoBehaviour
{
    public TMP_Text carText;
    public MonoBehaviour CarController;
    public Transform Car;
    public Transform Player;

    [Header("Cameras")]
    public GameObject PlayerCam;
    public GameObject CarCam;

    bool canDrive;
    bool driving;

    void Start()
    {
        CarController.enabled = false;
        PlayerCam.gameObject.SetActive(true);
        CarCam.gameObject.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && canDrive)
        {
            CarController.enabled = true;
            driving = true;
            Player.transform.SetParent(Car);
            Player.gameObject.SetActive(false);

            // Camera
            PlayerCam.gameObject.SetActive(false);
            CarCam.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            CarController.enabled = false;
            driving = false;

            Player.transform.SetParent(null);
            Player.gameObject.SetActive(true);

            // Camera
            PlayerCam.gameObject.SetActive(true);
            CarCam.gameObject.SetActive(false);
        }
    }


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

    private void OnTriggerStay(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            canDrive = true;
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

            canDrive = false;
        }
    }
}
