using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.GridSystem;
using System;

namespace Paintastic.ScoreManager
{
    public class ScoreManager : MonoBehaviour
    {
        private int player1 = 0;
        private int player2 = 0;
        [SerializeField] GameGrid gameGrid;

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

        }

        private void OnPlayerTilesCount(string arg1, int arg2)
        {
            if (arg1 == "Player") player1 += arg2;
            else player2 += arg2;

            Debug.Log(player1 + " and " + player2);
        }
    }
}
