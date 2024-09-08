using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BusTrigger : MonoBehaviour
{
    public TMP_Text carText;
    public GameObject UISprite;
    public MonoBehaviour CarController;
    public Transform Car;
    public Transform Player;

    [Header("Cameras")]
    public GameObject PlayerCam;
    public GameObject CarCam;
    public GameObject CarObj;

    bool canDrive;
    bool driving;

    private Rigidbody rb;

    void Start()
    {
        CarController.enabled = false;
        PlayerCam.gameObject.SetActive(true);
        CarCam.gameObject.SetActive(false);
        UISprite.gameObject.SetActive(false);
        rb = CarObj.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canDrive)
        {
            CarController.enabled = true;
            driving = true;
            Player.transform.SetParent(Car);
            Player.gameObject.SetActive(false);

            // Camera
            PlayerCam.gameObject.SetActive(false);
            CarCam.gameObject.SetActive(true);
            UISprite.gameObject.SetActive(false);

            rb.drag = 0;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            CarController.enabled = false;
            driving = false;

            Player.transform.SetParent(null);
            Player.gameObject.SetActive(true);
            UISprite.gameObject.SetActive(true);

            // Camera
            PlayerCam.gameObject.SetActive(true);
            CarCam.gameObject.SetActive(false);

            // After dismounting set the speed of the car to 0
            rb.drag = 20;

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            UISprite.gameObject.SetActive(true);
            // Draw a text box
            carText.text = "PRESS F\nTO DRIVE\nPRESS G\nTO EXIT";

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
            // Disengage the text box
            carText.text = "";
            UISprite.gameObject.SetActive(false);
            canDrive = false;
        }
    }
}

