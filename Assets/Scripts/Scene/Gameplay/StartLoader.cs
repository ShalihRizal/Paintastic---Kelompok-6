using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.GridSystem;
using Paintastic.ScoreManager;

public class StartLoader : MonoBehaviour
{
    [SerializeField] PlayerController _player1;
    [SerializeField] PlayerController _player2;
    [SerializeField] GameGrid _gameGrid;
    [SerializeField] SpawnerManager _spawner;

    void Start()
    {
        _player1.SetGrid(_gameGrid);
        _player2.SetGrid(_gameGrid);

        _gameGrid.InitStart(_player1, _player2);
        _spawner.InitStart(_player1, _player2);
    }
}
