using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ScreenManager : MonoBehaviour
{
    public static Action OnReset;
    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private GameObject youWin;

    private void Start()
    {
        PlayerStatsManager.OnDeath += ShowGameOver;
        TimeRemaining.OnFinished += ShowYouWin;
    }

    private void OnDisable()
    {
        PlayerStatsManager.OnDeath -= ShowGameOver;
        TimeRemaining.OnFinished -= ShowYouWin;
    }

    private void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    private void ShowYouWin()
    {
        youWin.SetActive(true);
        Time.timeScale = 0;
    }

    public void Retry()
    {
        OnReset?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        OnReset?.Invoke();
        SceneManager.LoadScene(0);
    }
}
