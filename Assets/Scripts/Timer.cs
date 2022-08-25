using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Paintastic.ScoreManager;

public class Timer : MonoBehaviour
{
    [SerializeField]
    float initialTime = 15f;

    [SerializeField]
    private TextMeshProUGUI timerText;

    [SerializeField]
    ScoreManager scoreManager;

    private void Update()
    {
        if (initialTime > 0)
        {
            initialTime -= Time.deltaTime;
        }
        else
        {
            initialTime = 0;
            scoreManager.OnTimesUp();
            Time.timeScale = 0;
            
        }

        DisplayTime(initialTime);
    }

    private void Awake()
    {
        Time.timeScale = 1;
    }

    void DisplayTime(float amountToDisplay)
    {
        if (amountToDisplay < 0)
        {
            amountToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(amountToDisplay / 60);
        float seconds = Mathf.FloorToInt(amountToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
