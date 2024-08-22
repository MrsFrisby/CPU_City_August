﻿using System.Collections;
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

    public string[] quests = { "Talk to Copper", "Check in with PC Reg Ister at the Police Station", "All complete dude!" };
    public int currentQuestIndex = 0;

    private float timerDuration = 20f;
    private float timeRemaining;
    private bool timerActive = false;
    private bool timerStarted = false;

    public Color startColor = Color.white;
    public Color endColor = Color.red;

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

        if(timerActive)
        {
            timerObject.SetActive(true);
            UpdateTimer();
        }
        else
        {
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
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        questText = GameObject.Find("Quest Text").GetComponent<TextMeshProUGUI>();
        timerText = GameObject.Find("Timer Text").GetComponent<TextMeshProUGUI>();
        timerImage = GameObject.Find("Timer Bar").GetComponent<Image>();
        timerObject = GameObject.Find("Timer");

    DisplayMainQuests();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}