using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.Timer;

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

        SpawnObject();
    }

    private void InstantiateNewOne(BaseCollectableObject obj, List<BaseCollectableObject> pool)
    {
        BaseCollectableObject clone = Instantiate(obj);
        pool.Add(clone);

        clone.InitInstantiate(_spawner.GetGrid());
    }

    private void SpawnObject()
    {
        BaseCollectableObject item = null;
        switch (Random.Range(0, 2))
        {
            case 0:
                item = GetItem(_collectPointPool);
                break;
            case 1:
                item = GetItem(_bombItemPool);
                break;
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
}
