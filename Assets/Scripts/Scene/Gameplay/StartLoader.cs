using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.GridSystem;
using Paintastic.ScoreManager;
using Paintastic.Timer;
using Paintastic.Player;

public class StartLoader : MonoBehaviour
{
    [SerializeField] private PlayerMovement[] players;
    [SerializeField] private GameGrid _gameGrid;
    [SerializeField] private SpawnerManager _spawner;
    [SerializeField] private PoolObject _pool;
    [SerializeField] private Timer _timer;
    [SerializeField] private ScoreManager _scoreManager;

    void Start()
    {
        _spawner.InitStart(_gameGrid, players);
        _pool.InitStart(_spawner, _timer);
        _scoreManager.StartInit(
            players[0].GetComponent<Player>(),
            players[1].GetComponent<Player>()
            );
    }
}
