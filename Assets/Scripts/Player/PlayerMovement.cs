using Paintastic.Audio;
using Paintastic.GridSystem;
using Paintastic.Spawner;
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
                if (path[current.x + target.x, current.y + target.y].GetCellAvailablility()) return;
                
                current += target;
                
                path[current.x, current.y].SetCellAvailablility();

                target = Vector2Int.zero;
                transform.position = path[current.x,current.y].transform.position;
                tmpTime = 0;
                AudioManager.instance.PlaySfx("SFX_StepTiles");
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
