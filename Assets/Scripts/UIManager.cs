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

    [SerializeField]
    private TextMeshProUGUI player1ScoreText;

    [SerializeField]
    private TextMeshProUGUI player2ScoreText;

    [SerializeField]
    private Image player1ScoreBar;

    [SerializeField]
    private Image player2ScoreBar;

    [SerializeField]
    private GameObject hud;

    [SerializeField]
    ScoreManager scoreManager;

    [SerializeField]
    private GameObject resultScreen;

    [SerializeField]
    private GameObject pauseButton;

    [SerializeField]
    private GameObject killfeedPanel;

    [SerializeField]
    private GameObject killfeedPrefab;

    [SerializeField]
    Timer timer;

    public Action<string, int> OnScored;

    private void OnEnable()
    {
        scoreManager.OnScoreChanged += OnScoreChanged;
        timer.OnTimesUp += onTimesUp;
        scoreManager.OnKillfeed += AddKillFeed;
    }

    private void OnDisable()
    {
        scoreManager.OnScoreChanged -= OnScoreChanged;
        timer.OnTimesUp -= onTimesUp;
        scoreManager.OnKillfeed -= AddKillFeed;
    }

    private void OnScoreChanged()
    {

        float totalScore = (float)scoreManager.GetPlayer1Score() + scoreManager.GetPlayer2Score();

        player1ScoreText.text = scoreManager.GetPlayer1Score().ToString();
        player2ScoreText.text = scoreManager.GetPlayer2Score().ToString();

        player1ScoreBar.fillAmount = scoreManager.GetPlayer1Score() / totalScore;
        player2ScoreBar.fillAmount = scoreManager.GetPlayer2Score() / totalScore;

    }

    private void Awake()
    {
        Color color;

        ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("Player1Color"), out color);
        player1ScoreBar.color = color;

        ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("Player2Color"), out color);
        player2ScoreBar.color = color;

    }

    void AddKillFeed(string playerName, int score)
    {
        OnScored?.Invoke(playerName, score);
    }

    void onTimesUp()
    {
        hud.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        resultScreen.SetActive(true);
    }
}
