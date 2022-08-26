using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.GridSystem;
using System;
using Paintastic.Timer;
using Paintastic.Player;

namespace Paintastic.ScoreManager
{
    public class ScoreManager : MonoBehaviour
    {
        private int player1 = 0;
        private int player2 = 0;

        Player.Player player1Object;
        Player.Player player2Object;

        [SerializeField] 
        Timer.Timer timer;

        [SerializeField] GameObject disableScore;

        public Action OnScoreChanged;

        public void StartInit(Player.Player p1, Player.Player p2)
        {
            player1Object = p1;
            player2Object = p2;

            player1Object.OnSendScore += OnPlayerTilesCount;
            player2Object.OnSendScore += OnPlayerTilesCount;
        }

        private void OnDisable()
        {
            player1Object.OnSendScore -= OnPlayerTilesCount;
            player2Object.OnSendScore -= OnPlayerTilesCount;
        }

        private void OnPlayerTilesCount(string arg1, int arg2)
        {
            if (arg1 == "Player1")
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
