using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnObject
{
    public Action<ISpawnObject> DeActiveObject { get; set; }
    public void SpawnObject(Vector2Int _pos);
    public Vector2Int GetCurrentPosition();
}
