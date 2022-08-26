using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Paintastic.ScoreManager;

namespace Paintastic.Timer
{
    public class Timer : MonoBehaviour
    {

        public Action OnTimeToSpawn;

        [SerializeField]
        float initialTime = 15f;

        [SerializeField]
        float timeToSpawn = 8f;

        [SerializeField]
        private TextMeshProUGUI timerText;

        [SerializeField]
        ScoreManager.ScoreManager scoreManager;

        private void Update()
        {
            if (initialTime > 0)
            {
                initialTime -= Time.deltaTime;
                timeToSpawn -= Time.deltaTime;

                if (timeToSpawn <= 0)
                {
                    OnTimeToSpawn?.Invoke();
                    timeToSpawn = 8;
                }
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
}
