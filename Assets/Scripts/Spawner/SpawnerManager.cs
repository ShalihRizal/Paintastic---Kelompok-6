using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.GridSystem;

public class SpawnerManager : MonoBehaviour
{
    private GameGrid _gameGrid;

    private PlayerController player1;
    private PlayerController player2;

    private List<ISpawnObject> objectInField;

    public void InitStart(GameGrid gg, PlayerController p1, PlayerController p2)
    {
        objectInField = new List<ISpawnObject>();

        _gameGrid = gg;

        player1 = p1;
        player2 = p2;

        objectInField.Add(player1);
        objectInField.Add(player2);

        player1.SetSpawn(player2, Vector2Int.zero, _gameGrid);
        player2.SetSpawn(player1, new Vector2Int(7, 7), _gameGrid);
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
}
