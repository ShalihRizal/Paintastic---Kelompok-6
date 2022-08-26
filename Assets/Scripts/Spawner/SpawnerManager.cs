using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.GridSystem;
using Paintastic.Player;

public class SpawnerManager : MonoBehaviour
{
    private GameGrid _gameGrid;

    private PlayerMovement player1;
    private PlayerMovement player2;

    private List<ISpawnObject> objectInField;

    public void InitStart(GameGrid gg, PlayerMovement p1, PlayerMovement p2)
    {
        objectInField = new List<ISpawnObject>();

        _gameGrid = gg;

        player1 = p1;
        player2 = p2;

        objectInField.Add(player1);
        objectInField.Add(player2);

        player1.StartInit(_gameGrid.GetGrid(), Vector2Int.zero);
        player2.StartInit(_gameGrid.GetGrid(), new Vector2Int(_gameGrid.gridwidth - 1, _gameGrid.gridHeight - 1));
    }

    public void RequestSpawnPos(ISpawnObject _object)
    {
        Vector2Int randPos = new Vector2Int();
        do
        {
            randPos = new Vector2Int(
                Random.Range(0, _gameGrid.GetGrid().GetLength(0)),
                Random.Range(0, _gameGrid.GetGrid().GetLength(1))
                );
        } while (!CheckCanSpawn(randPos));

        _object.SpawnObject(randPos, _gameGrid.GetGrid()[randPos.x, randPos.y].transform);

        objectInField.Add(_object);
        _object.DeActiveObject += ObjectDeActive;
    }

    private bool CheckCanSpawn(Vector2Int v2) 
    {
        foreach(ISpawnObject obj in objectInField)
        {
            if (v2 == obj.GetCurrentPosition()) return false;
        }

        return true;
    }

    private void ObjectDeActive(ISpawnObject obj) => objectInField.Remove(obj);
    public GridCell[,] GetGrid() => _gameGrid.GetGrid();
}
