﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public TextMeshProUGUI questText;
    public TextMeshProUGUI timerText;
    public Image timerImage;

    public GameObject timerObject;

    public string[] quests = { "Talk to Copper", "Check in with PC Reg Ister at the Police Station", "Talk to Marvin about the pigeon", "Speak to the caretaker at the RAM headquarters", "Collect the pigeon in location 38", "Talk to Copper", "All tasks done!" };
    public int currentQuestIndex = 0;

    private float timerDuration = 600f;
    private float timeRemaining;
    private bool timerActive = false;
    private bool timerStarted = false;

    public Color startColor = Color.white;
    public Color endColor = Color.red;

    private bool endOfGame = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        DisplayMainQuests();

        if(currentQuestIndex == quests.Length - 1 && !Initiate.areWeFading && !endOfGame)
        {
            timerActive = false;
            endOfGame = true;
            Initiate.Fade("11_Congratulations", new Color(105f / 255f, 131f / 255f, 204f / 255f), 0.5f);
        }

        if(timerActive)
        {
            timerObject.SetActive(true);
            UpdateTimer();
        }
        else
        {
            if(currentQuestIndex != quests.Length - 1)
                timerObject.SetActive(false);
        }
    }


    private void DisplayMainQuests()
    {
        if (currentQuestIndex <= quests.Length)
        {
            questText.text = quests[currentQuestIndex];
            if (currentQuestIndex > 0 && !timerActive && !timerStarted)
            {
                StartTimer();
                timerStarted = true;
            }
        }
    }

    private void StartTimer()
    {
        timeRemaining = timerDuration;
        timerActive = true;
    }

    private void UpdateTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            timerActive = false;
            DisplayTime(timeRemaining);
            TimerHasEnded();
        }
    }

    private void DisplayTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        timerImage.fillAmount = timeRemaining / timerDuration;
        Color timerColor = Color.Lerp(endColor, startColor, time / timerDuration);
        timerImage.color = timerColor;
    }

     private void TimerHasEnded()
    {
        Debug.Log("Timer has ended!");
        SceneManager.LoadScene("12_TimesUp"); // Load the "Time's Up" scene when time runs out
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (currentQuestIndex == 4)
        {
            currentQuestIndex = 5;
        }

        if (currentQuestIndex != quests.Length - 1)
        {
            questText = GameObject.Find("Quest Text").GetComponent<TextMeshProUGUI>();
            timerText = GameObject.Find("Timer Text").GetComponent<TextMeshProUGUI>();
            timerImage = GameObject.Find("Timer Bar").GetComponent<Image>();
            timerObject = GameObject.Find("Timer");

            DisplayMainQuests();
        }     
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Method to reset the game timer and display quests
    public void RestartGameTimer()
    {
        currentQuestIndex = 0; // Reset quest to the start
        endOfGame = false;
        timerStarted = false;   // Ensure timer hasn't started yet
        timerActive = false;    // Make sure the timer is inactive
        timeRemaining = timerDuration; // Reset the timer duration
        DisplayMainQuests();    // Display the first quest without starting the timer

        Debug.Log("Game has been restarted and the timer is reset!");
    }
}

