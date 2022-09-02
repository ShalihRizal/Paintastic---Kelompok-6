using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paintastic.Spawner
{
    public interface ISpawnObject
    {
        public Action<ISpawnObject> DeActiveObject { get; set; }
        public void SpawnObject(Vector2Int _pos, Transform _transform);
        public Vector2Int GetCurrentPosition();
    }
}