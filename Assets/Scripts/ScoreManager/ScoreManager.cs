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
        /*private int player1 = 0;
        private int player2 = 0;*/
        private int[] player;

        /*Player.Player player1Object;
        Player.Player player2Object;*/
        Player.Player[] playerObject;

        [SerializeField]
        Timer.Timer timer;

        [SerializeField] GameObject disableScore;

        public Action OnScoreChanged;
        public Action<string, int> OnKillfeed;

        public void StartInit(Player.Player[] p)
        {
            /*player1Object = p1;
            player2Object = p2;*/
            playerObject = new Player.Player[p.Length];
            player = new int[p.Length];
            for(int i = 0; i < p.Length; i++)
            {
                playerObject[i] = p[i];
                playerObject[i].OnSendScore += OnPlayerTilesCount;
            }
            /*player1Object.OnSendScore += OnPlayerTilesCount;
            player2Object.OnSendScore += OnPlayerTilesCount;*/
        }

        private void OnPlayerTilesCount(string arg1, int arg2)
        {
            //Debug.Log("OnPlayerTilesCount");
            /*foreach (int i in player)
            {
                Debug.Log("Player" + (i + 1));
                if (arg1 == "Player" + (i + 1))
                {
                    player[i] += arg2;
                }
            }*/
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
        }

        private void OnDisable()
        {
            for (int i = 0; i < playerObject.Length; i++)
            {
                playerObject[i].OnSendScore -= OnPlayerTilesCount;
            }
        }

        /*private void OnPlayerTilesCount(string arg1, int arg2)
        {
            *//*if (arg1 == "Player1")
            {
                player1 += arg2;
            }
            else
            {
                player2 += arg2;
            }
*//*
            Debug.Log("OnPlayerTilesExecute");
            foreach(int i in player)
            {
                    Debug.Log("Player" + (i + 1));
                if (arg1 == "Player" + (i + 1))
                {
                    player[i] += arg2;
                }
            }

            OnScoreChanged?.Invoke();
            OnKillfeed?.Invoke(arg1, arg2);

            //Debug.Log(player1 + " and " + player2);
        }*/
        public void OnTimesUp()
        {
            timer.OnTimesUp += disable;
        }

        void disable()
        {
            disableScore.SetActive(false);
        }

        /*public int GetPlayer1Score()
        {
            return player1;
        }

        public int GetPlayer2Score()
        {
            return player2;
        }*/
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
