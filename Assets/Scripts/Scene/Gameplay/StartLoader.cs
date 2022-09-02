using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.GridSystem;
using Paintastic.ScoreManager;
using Paintastic.Timer;
using Paintastic.Player;
using Paintastic.Spawner;
using Paintastic.CollectibleObject;

namespace Paintastic.StartLoader
{
    public class StartLoader : MonoBehaviour
    {
        [SerializeField] private PlayerMovement[] players;
        [SerializeField] private Player.Player[] playerClass;
        [SerializeField] private GameGrid _gameGrid;
        [SerializeField] private SpawnerManager _spawner;
        [SerializeField] private PoolObject _pool;
        [SerializeField] private Timer.Timer _timer;
        [SerializeField] private ScoreManager.ScoreManager _scoreManager;

        void Start()
        {
            _gameGrid.StartInit();
            _spawner.InitStart(_gameGrid, players);
            _pool.InitStart(_spawner, _timer);
            _scoreManager.InitStart(playerClass);
        }
    }
}