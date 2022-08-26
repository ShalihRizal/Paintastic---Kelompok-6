using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.GridSystem;
using Paintastic.ScoreManager;
using Paintastic.Timer;

public class StartLoader : MonoBehaviour
{
    [SerializeField] PlayerController _player1;
    [SerializeField] PlayerController _player2;
    [SerializeField] GameGrid _gameGrid;
    [SerializeField] SpawnerManager _spawner;
    [SerializeField] PoolObject _pool;
    [SerializeField] Timer _timer;

    void Start()
    {
        _gameGrid.InitStart(_player1, _player2);
        _spawner.InitStart(_gameGrid, _player1, _player2);
        _pool.InitStart(_spawner, _timer);
    }
}
