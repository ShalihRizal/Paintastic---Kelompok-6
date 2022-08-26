using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.GridSystem;
using System;
using Paintastic.Timer;

namespace Paintastic.ScoreManager
{
    public class ScoreManager : MonoBehaviour
    {
        private int player1 = 0;
        private int player2 = 0;

        [SerializeField] 
        GameGrid gameGrid;

        [SerializeField] 
        Timer.Timer timer;

        private bool isOver = false;

        [SerializeField] GameObject disableScore;

        public Action OnScoreChanged;

        private void OnEnable()
        {
            gameGrid.OnPlayerTilesCount += OnPlayerTilesCount;
        }
        private void OnDisable()
        {
            gameGrid.OnPlayerTilesCount -= OnPlayerTilesCount;

        }
        void Update()
        {
            //kondisi waktu habis

        }

        private void OnPlayerTilesCount(string arg1, int arg2)
        {
            if (arg1 == "Player")
            {
                player1 += arg2;
            }
            else
            {
                player2 += arg2;
            }

            OnScoreChanged?.Invoke();

            Debug.Log(player1 + " and " + player2);
        }
        public void OnTimesUp()
        {
            timer.OnTimesUp += disable;
        }

        void disable()
        {
            //resultScreen.SetActive(true);
            disableScore.SetActive(false);
        }

        public int GetPlayer1Score()
        {
            return player1;
        }

        public int GetPlayer2Score()
        {
            return player2;
        }
    }
}
