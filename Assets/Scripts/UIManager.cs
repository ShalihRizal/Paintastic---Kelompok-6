using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.ScoreManager;
using System;
using TMPro;
using Paintastic.Timer;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    /*[SerializeField]
    private TextMeshProUGUI player1ScoreText;

    [SerializeField]
    private TextMeshProUGUI player2ScoreText;*/

    [SerializeField]
    private TextMeshProUGUI[] playerScoreText;

    /*[SerializeField]
    private Image player1ScoreBar;

    [SerializeField]
    private Image player2ScoreBar;
    */
    [SerializeField]
    private Image[] playerScoreBar;

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

    float fillamount;

    private void Update()
    {
        scoreManager.OnScoreChanged += OnScoreChanged;
        timer.OnTimesUp += onTimesUp;
    }

    private void OnScoreChanged()
    {
        /*player1ScoreText.text = scoreManager.GetPlayer1Score().ToString();
        player2ScoreText.text = scoreManager.GetPlayer2Score().ToString();*/
        for (int i = 0; i < playerScoreText.Length; i++)
        {
            playerScoreText[i].text = scoreManager.GetPlayerScore(i).ToString();
            playerScoreBar[i].fillAmount = (float) scoreManager.GetPlayerScore(i) / GetTotalScore();
            
        }
        /*player1ScoreBar.fillAmount = scoreManager.GetPlayer1Score() / totalScore;
        player2ScoreBar.fillAmount = scoreManager.GetPlayer2Score() / totalScore;*/
    }
    private void Awake()
    {
        Color color;

        for (int i = 1; i < playerScoreBar.Length + 1; i++)
        {
            ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("Player" + i + "Color"), out color);
            playerScoreBar[i - 1].color = color;
        }

        /*ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("Player1Color"), out color);
        player1ScoreBar.color = color;

        ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("Player2Color"), out color);
        player2ScoreBar.color = color;*/

    }

    int GetTotalScore()
    {
        int totalScore = 0;
        for (int i = 0; i < playerScoreBar.Length; i++)
        {
            totalScore += scoreManager.GetPlayerScore(i);
        }
        return totalScore;
    }

    void onTimesUp()
    {

        hud.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        resultScreen.SetActive(true);
    }
}
