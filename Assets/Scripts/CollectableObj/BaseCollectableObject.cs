using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.GridSystem;

public abstract class BaseCollectableObject : MonoBehaviour, ISpawnObject
{
    public Action<ISpawnObject> DeActiveObject { get; set;  }

    private Vector2Int v2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>()) 
            Activation();
    }

    public Vector2Int GetCurrentPosition() => v2;

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

    private void Activation()
    {
        ActiveEfect();
        SetDeActiveObject();
    }

    private void SetDeActiveObject()
    {
        DeActiveObject(this);
        gameObject.SetActive(false);
    }

    public abstract void ActiveEfect();
    public abstract void SubscribeActivation(Action action);
}
