using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 60;
    public bool timerIsRunning = false;
    public TMP_Text timeText;

    private Tween timerTextTween;


    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        DisplayTime();
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime()
    {
        float currentValue = 10800;
        timerTextTween = DOTween.To(() => currentValue, x => currentValue = x, 0, timeRemaining).SetEase(Ease.Linear).OnUpdate(() =>
        {
            float minutes = Mathf.FloorToInt(currentValue / 60);
            float seconds = Mathf.FloorToInt(currentValue % 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        });
    }
}