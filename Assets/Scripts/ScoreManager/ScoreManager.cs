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

        private int[] player;

        Player.Player[] playerObject;

        [SerializeField]
        Timer.Timer timer;

        [SerializeField] GameObject disableScore;

        public Action OnScoreChanged;
        public Action<string, int> OnKillfeed;

        public void StartInit(Player.Player[] p)
        {

            playerObject = new Player.Player[p.Length];
            player = new int[p.Length];
            for(int i = 0; i < p.Length; i++)
            {
                playerObject[i] = p[i];
                playerObject[i].OnSendScore += OnPlayerTilesCount;
            }

        }

        private void OnPlayerTilesCount(string arg1, int arg2)
        {
            for(int i = 0; i < playerObject.Length; i++)
            {
                if(arg1.Equals("Player" + (i + 1)))
                {
                    Debug.Log("Execute");
                    player[i] += arg2;
                }
            }
            Debug.Log(player[0]+" and "+player[1]);
            OnScoreChanged?.Invoke();
            OnKillfeed?.Invoke(arg1, arg2);
        }

        private void OnDisable()
        {
            for (int i = 0; i < playerObject.Length; i++)
            {
                playerObject[i].OnSendScore -= OnPlayerTilesCount;
            }
        }

        public void OnTimesUp()
        {
            timer.OnTimesUp += disable;
        }

        void disable()
        {
            disableScore.SetActive(false);
        }

        public int GetPlayerScore(int index)
        {
            return player[index];
        }
        public int[] GetPlayerScore()
        {
            return player;
        }
    }
}
