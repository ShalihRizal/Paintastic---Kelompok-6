using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.Timer;
using Paintastic.CollectibleObject;

public class PoolObject : MonoBehaviour
{
    [SerializeField] CollectPointItem _collectPointItem;
    [SerializeField] BombItem _bombItem;

    [SerializeField] int _size;

    private List<BaseCollectableObject> _collectPointPool;
    private List<BaseCollectableObject> _bombItemPool;

    private SpawnerManager _spawner;
    private Timer _timer;

    private void OnDisable()
    {
        _timer.OnTimeToSpawn -= SpawnObject;
    }

    public void InitStart(SpawnerManager spawner, Timer timer)
    {
        _spawner = spawner;
        _timer = timer;

        _timer.OnTimeToSpawn += SpawnObject;

        _collectPointPool = new List<BaseCollectableObject>();
        _bombItemPool = new List<BaseCollectableObject>();

        for (int i = 0; i < _size; i++)
        {
            InstantiateNewOne(_collectPointItem, _collectPointPool);
            InstantiateNewOne(_bombItem, _bombItemPool);
        }
    }

    private void InstantiateNewOne(BaseCollectableObject obj, List<BaseCollectableObject> pool)
    {
        BaseCollectableObject clone = Instantiate(obj);
        pool.Add(clone);

        clone.InitInstantiate(_spawner.GetGrid(), SpawnItemIfFieldEmpty);
    }

    private void SpawnObject()
    {
        BaseCollectableObject item = null;
        int r = Random.Range(0, 10);
        if (r<3)
        {
            item = GetItem(_bombItemPool);
        }
        else
        {
            item = GetItem(_collectPointPool);
        }

        if (item)
            _spawner.RequestSpawnPos(item);
    }

    private BaseCollectableObject GetItem(List<BaseCollectableObject> pool)
    {
        foreach (BaseCollectableObject obj in pool)
        {
            if (!obj.gameObject.activeInHierarchy) 
                return obj;
        }

        return null;
    }

    private void SpawnItemIfFieldEmpty()
    {
        foreach (BaseCollectableObject obj in _collectPointPool)
        {
            if (obj.gameObject.activeInHierarchy) return;
        }

        foreach (BaseCollectableObject obj in _bombItemPool)
        {
            if (obj.gameObject.activeInHierarchy) return;
        }

        SpawnObject();
    }
}
