using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeRemaining : MonoBehaviour
{
    [SerializeField]
    private float timeInSeconds = 600;
    [SerializeField]
    private TextMeshProUGUI timeText;

    private void Update()
    {
        timeInSeconds -= Time.deltaTime;
        if (timeInSeconds <= 0) timeInSeconds = 0;
        DisplayTime();
    }

    private void DisplayTime()
    {
        float minutes = Mathf.FloorToInt(timeInSeconds / 60);
        float seconds = Mathf.FloorToInt(timeInSeconds % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
