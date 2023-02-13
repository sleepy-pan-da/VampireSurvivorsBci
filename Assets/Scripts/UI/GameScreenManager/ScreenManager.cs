using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ScreenManager : MonoBehaviour
{
    public static Action OnReset;
    [SerializeField]
    private GameObject gameOverScreen;
    [SerializeField]
    private GameObject youWinScreen;
    [SerializeField]
    private GameObject pausedScreen;
    private bool isPaused = false;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) TogglePause();
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        TogglePausedScreen();
        if (isPaused) Time.timeScale = 0;
        else Time.timeScale = 1;  
    }

    private void TogglePausedScreen()
    {
        if (isPaused) pausedScreen.SetActive(true);
        else pausedScreen.SetActive(false);
    }

    private void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
    }

    private void ShowYouWin()
    {
        youWinScreen.SetActive(true);
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
