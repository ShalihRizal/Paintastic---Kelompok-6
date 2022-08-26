using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.GridSystem;
using Paintastic.ScoreManager;
using Paintastic.Timer;
using Paintastic.Player;

public class StartLoader : MonoBehaviour
{
    [SerializeField] PlayerMovement _player1;
    [SerializeField] PlayerMovement _player2;
    [SerializeField] GameGrid _gameGrid;
    [SerializeField] SpawnerManager _spawner;
    [SerializeField] PoolObject _pool;
    [SerializeField] Timer _timer;
    [SerializeField] ScoreManager _scoreManager;

    void Start()
    {
        _spawner.InitStart(_gameGrid, _player1, _player2);
        _pool.InitStart(_spawner, _timer);
        _scoreManager.StartInit(
            _player1.GetComponent<Player>(),
            _player2.GetComponent<Player>()
            );
    }
}
