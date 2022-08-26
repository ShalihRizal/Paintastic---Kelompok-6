using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.GridSystem;
using Paintastic.Player;

public abstract class BaseCollectableObject : MonoBehaviour, ISpawnObject
{
    public Action<ISpawnObject> DeActiveObject { get; set;  }
    public Action OnSpawnInField;

    private Vector2Int v2;
    private GridCell[,] _grid;

    private void OnTriggerEnter(Collider other)
    {
        Player subject = other.transform.parent.GetComponent<Player>();
        if (subject)
        {
            Activation(subject);
        }
    }

    public void InitInstantiate(GridCell[,] grid)
    {
        _grid = grid;
        gameObject.SetActive(false);
    }

    public void SpawnObject(Vector2Int _pos, Transform _transform)
    {
        v2 = _pos;

        transform.position = new Vector3(
            _transform.position.x,
            transform.position.y,
            _transform.position.z
        );

        gameObject.SetActive(true);
    }

    public Vector2Int GetCurrentPosition() => v2;

    private void Activation(Player subject)
    {
        ActiveEfect(_grid, subject);
        SetDeActiveObject();
    }

    private void SetDeActiveObject()
    {
        DeActiveObject(this);
        gameObject.SetActive(false);
    }

    public abstract void ActiveEfect(GridCell[,] _grid, Player activator);
}
