using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCollectableObject : MonoBehaviour, ISpawnObject
{
    public Action<ISpawnObject> DeActiveObject { get; set;  }

    private Vector2Int v2;

    public Vector2Int GetCurrentPosition()
    {
        return v2;
    }

    public void SpawnObject(Vector2Int _pos)
    {
        v2 = _pos;
    }

    private void DeActive()
    {
        DeActiveObject(this);
    }

    public abstract void ActiveEfect();
}
