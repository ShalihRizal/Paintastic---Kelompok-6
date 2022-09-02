using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.ScoreManager;
using System;
using TMPro;
using Paintastic.Timer;
using UnityEngine.UI;

namespace Paintastic.UIManager
{
    public class UIManager : MonoBehaviour
    {

        [SerializeField]
        private TextMeshProUGUI[] playerScoreText;

        [SerializeField]
        private Image[] playerScoreBar;

        [SerializeField]
        private GameObject hud;

        [SerializeField]
        ScoreManager.ScoreManager scoreManager;

        [SerializeField]
        private GameObject resultScreen;

        [SerializeField]
        private GameObject pauseButton;

        [SerializeField]
        Timer.Timer timer;

        float fillamount;
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
            for (int i = 0; i < playerScoreText.Length; i++)
            {
                playerScoreText[i].text = scoreManager.GetPlayerScore(i).ToString();
                playerScoreBar[i].fillAmount = (float)scoreManager.GetPlayerScore(i) / GetTotalScore();

            }
        }
        private void Awake()
        {
            Color color;

            for (int i = 1; i < playerScoreBar.Length + 1; i++)
            {
                ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("Player" + i + "Color"), out color);
                playerScoreBar[i - 1].color = color;
            }
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
        void AddKillFeed(string playerName, int score)
        {
            OnScored?.Invoke(playerName, score);
        }
    }
}