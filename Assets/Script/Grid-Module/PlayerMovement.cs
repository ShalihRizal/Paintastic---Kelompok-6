using Paintastic.GridSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paintastic.Player
{
    public class PlayerMovement : MonoBehaviour, ISpawnObject
    {
        private int pathWidth, pathHeigh;
        private GridCell[,] path;
        [SerializeField]
        private Vector2Int current = new Vector2Int();
        private Vector2Int target = new Vector2Int();
        private float walkDelay = .15f, tmpTime = 0;

        public Action<ISpawnObject> DeActiveObject { get; set; }

        /*public void SetInit(PlayerController anotherPlayer, GameObject[,] path, Vector2Int spawnPoint)
        {
            for (int i = 0; i < path.GetLength(0); i++)
            {
                for (int j = 0; j < path.GetLength(1); j++)
                {
                    this.gameGrid[i, j] = path[i, j].transform;
                }
            }
            current = spawnPoint;

            transform.position = this.path[current.x, current.y].transform.position;
            //transform.position = new Vector3(this.path[current.x, current.y].position.x, 10f, this.path[current.x, current.y].position.y);
        }*/

        /*public void SetInit(GameObject player, GameObject[,] grid, Vector2Int spawnPoint)
        {
            Vector3 bottomLeft = grid[0,0].transform.position;
            Vector3 bottomRight = grid[0, grid.Length-1].transform.position;
            Vector3 topLeft = grid[grid.Length - 1, 0].transform.position;
            Vector3 topRight = grid[grid.Length - 1, grid.Length - 1].transform.position;

        }*/

        public void StartInit(GridCell[,] _path, Vector2Int _pos)
        {
            path = _path;
            pathHeigh = path.GetLength(0);
            pathWidth = path.GetLength(1);

            SpawnObject(_pos, path[_pos.x, _pos.y].transform);
        }

        void Update()
        {
            PlayerMove();
        }

        private void PlayerMove()
        {
            tmpTime += Time.deltaTime;
            if (tmpTime > walkDelay)
            {
                //if (current + target == anotherPlayer.GetPlayerPos()) return;
                if (path[current.x+target.x, current.y+target.y].GetCellAvailablility()) return;
                current += target;

                target = Vector2Int.zero;
                //transform.position = Vector3.Lerp(transform.position, new Vector3(path[current.x, current.y].position.x, transform.position.y, path[current.x, current.y].position.z), 1f);
                transform.position = path[current.x,current.y].transform.position;
                tmpTime = 0;
            }
        }

        public void PlayerDir(Vector2Int dir)
        {
            if (current.x + dir.x < 0 || current.x + dir.x >= pathWidth
                || current.y + dir.y < 0 || current.y + dir.y >= pathHeigh) return;

            target = dir;
        }

        public Vector2Int GetPlayerPos() => current;

        public void SpawnObject(Vector2Int _pos, Transform _transform)
        {
            current = _pos;

            transform.position =
                new Vector3(
                    _transform.position.x,
                    transform.position.y,
                    _transform.position.z
                );
        }

        public Vector2Int GetCurrentPosition() => current;
    }
}
