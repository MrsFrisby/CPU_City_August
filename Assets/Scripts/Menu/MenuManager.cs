using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuCanvas;


    private bool isPaused;

    private void Start()
    {
        _pauseMenuCanvas.SetActive(false);

    }

    private void Update()
    {
        if (InputManager.instance.MenuOpenCloseInput)
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        OpenPauseMenu();
    }

    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1f;

        ClosePauseMenu();
    }

    private void OpenPauseMenu()
    {
        _pauseMenuCanvas.SetActive(true);
    }

    private void ClosePauseMenu()
    {
        _pauseMenuCanvas.SetActive(false);
    }

    public void ResumePress()
    {
        Unpause();
    }

    public void PauseButton()
    {
        Pause();
    }

    public void RestartGameTimer()
    {
        // Call the RestartGameTimer method from the GameManager
        if (GameManager.Instance != null)
        {
            GameManager.Instance.RestartGameTimer();
            Unpause(); // Unpause the game if it was paused
        }
        else
        {
            Debug.LogWarning("GameManager restart instance not found!");
        }
    }
}
