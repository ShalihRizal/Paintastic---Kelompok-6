using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.GridSystem;

public class PlayerController : MonoBehaviour, ISpawnObject
{
    private GameGrid _grid;

    private ISpawnObject anotherPlayer = null;
    private Vector2Int currentPos = new Vector2Int();
    private Vector2Int targetPos = new Vector2Int();
    private float walkDelay=.15f, tmpTime=0;

    public Action<ISpawnObject> DeActiveObject { get; set; }
    
    public void SetSpawn(PlayerController anotherPlayer, Vector2Int spawnPoint, GameGrid gg)
    {
        this.anotherPlayer = anotherPlayer;
        _grid = gg;

        SpawnObject(spawnPoint, _grid.GetGrid()[spawnPoint.x, spawnPoint.y].transform);
    }

    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        tmpTime += Time.deltaTime;
        if (tmpTime > walkDelay)
        {
            if (currentPos + targetPos == anotherPlayer.GetCurrentPosition()) return;
            currentPos += targetPos;
            targetPos = Vector2Int.zero;

            Transform currentPath = _grid.GetGrid()[currentPos.x, currentPos.y].transform;
            transform.position = Vector3.Lerp(transform.position, new Vector3(currentPath.position.x, transform.position.y, currentPath.position.z), 1f);
            //transform.position = new Vector3(target.x, target.y, transform.position.z);
            tmpTime = 0;
        }
    }

    public void PlayerDir(Vector2Int dir)
    {
        if (currentPos.x + dir.x < 0 || currentPos.x + dir.x > 7
            || currentPos.y + dir.y < 0 || currentPos.y + dir.y > 7) return;

        targetPos = dir;
    }

    public void SpawnObject(Vector2Int _pos, Transform _transform)
    {
        currentPos = _pos;

        transform.position = 
            new Vector3(
                _transform.position.x,
                transform.position.y,
                _transform.position.z
            );
    }

    public Vector2Int GetCurrentPosition() => currentPos;
}
