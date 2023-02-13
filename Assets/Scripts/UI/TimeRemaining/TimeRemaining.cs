using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeRemaining : MonoBehaviour
{
    public static event Action OnFinished;

    [SerializeField]
    private float timeInSeconds = 600;
    [SerializeField]
    private TextMeshProUGUI timeText;
    private bool isEnabled = true;

    private void Start()
    {
        PlayerStatsManager.OnDeath += Disable;
    }

    private void OnDisable()
    {
        PlayerStatsManager.OnDeath -= Disable;
    }

    private void Disable()
    {
        isEnabled = false;
    }

    private void Update()
    {
        if (isEnabled)
        {
            timeInSeconds -= Time.deltaTime;
            if (timeInSeconds <= 0)
            {
                timeInSeconds = 0;
                Disable();
                OnFinished?.Invoke();
            } 
            DisplayTime();
        }
    }

    private void DisplayTime()
    {
        float minutes = Mathf.FloorToInt(timeInSeconds / 60);
        float seconds = Mathf.FloorToInt(timeInSeconds % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
