using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.ScoreManager;
using System;
using TMPro;
using Paintastic.Timer;

public class UIManager : MonoBehaviour
{

    /*[SerializeField]
    private TextMeshProUGUI player1ScoreText;

    [SerializeField]
    private TextMeshProUGUI player2ScoreText;*/
    
    [SerializeField]
    private TextMeshProUGUI[] playerScoreText;

    [SerializeField]
    private GameObject hud;

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
        /*player1ScoreText.text = scoreManager.GetPlayer1Score().ToString();
        player2ScoreText.text = scoreManager.GetPlayer2Score().ToString();*/
        for(int i = 0; i < playerScoreText.Length; i++)
        {
            playerScoreText[i].text = scoreManager.GetPlayerScore(i).ToString();
        }
    }

    void onTimesUp()
    {

        hud.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        resultScreen.SetActive(true);
    }
}
