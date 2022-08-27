using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.ScoreManager;
using System;
using TMPro;
using Paintastic.Timer;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI player1ScoreText;

    [SerializeField]
    private TextMeshProUGUI player2ScoreText;

    [SerializeField]
    private TextMeshProUGUI timerText;

    [SerializeField]
    ScoreManager scoreManager;

    [SerializeField]
    private GameObject resultScreen;

    [SerializeField]
    private GameObject pauseButton;

    [SerializeField]
    Timer timer;

    private void Update()
    {
        scoreManager.OnScoreChanged += OnScoreChanged;
        timer.OnTimesUp += onTimesUp;
    }

    private void OnScoreChanged()
    {
        player1ScoreText.text = "Player 1 : " + scoreManager.GetPlayer1Score().ToString();
        player2ScoreText.text = "Player 2 : " + scoreManager.GetPlayer2Score().ToString();
    }

    void onTimesUp()
    {
        player1ScoreText.gameObject.SetActive(false);
        player2ScoreText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        resultScreen.SetActive(true);
    }
}
