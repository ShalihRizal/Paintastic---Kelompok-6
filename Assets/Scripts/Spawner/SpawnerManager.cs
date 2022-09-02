using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.GridSystem;
using Paintastic.Player;

namespace Paintastic.Spawner
{
    public class SpawnerManager : MonoBehaviour
    {
        private GameGrid _gameGrid;

        private PlayerMovement[] _players;

        private List<ISpawnObject> objectInField;

        public void InitStart(GameGrid gg, PlayerMovement[] players)
        {
            objectInField = new List<ISpawnObject>();

            _gameGrid = gg;

            _players = players;

            Vector2Int[] spawnPos = new Vector2Int[4] {
            new Vector2Int(0, 0),
            new Vector2Int(_gameGrid.gridwidth - 1 , _gameGrid.gridHeight - 1),
            new Vector2Int(0, _gameGrid.gridHeight - 1),
            new Vector2Int(_gameGrid.gridwidth - 1, 0)
        };

            int idx = 0;
            foreach (PlayerMovement player in _players)
            {
                objectInField.Add(player);

                if (idx < 4)
                {
                    player.StartInit(_gameGrid.GetGrid(), spawnPos[idx]);
                    idx++;
                }
                else RequestSpawnPos(player);
            }
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
            foreach (ISpawnObject obj in objectInField)
            {
                if (v2 == obj.GetCurrentPosition()) return false;
            }

            return true;
        }

        private void ObjectDeActive(ISpawnObject obj) => objectInField.Remove(obj);
        public GridCell[,] GetGrid() => _gameGrid.GetGrid();
    }
}