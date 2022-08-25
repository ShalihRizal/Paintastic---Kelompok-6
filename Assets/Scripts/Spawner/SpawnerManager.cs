using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    private PlayerController player1;
    private PlayerController player2;

    private List<ISpawnObject> objectInField;

    public void InitStart(PlayerController p1, PlayerController p2)
    {
        objectInField = new List<ISpawnObject>();

        player1 = p1;
        player2 = p2;

        objectInField.Add(player1);
        objectInField.Add(player2);

        player1.SetSpawn(player2, Vector2Int.zero);
        player2.SetSpawn(player1, new Vector2Int(7, 7));
    }

    public void RequestSpawnPos(ISpawnObject _object)
    {
        Vector2Int randPos = new Vector2Int();
        do
        {
            randPos = new Vector2Int();
        } while (!CheckCanSpawn(randPos));

        _object.SpawnObject(randPos);

        objectInField.Add(_object);
        _object.DeActiveObject += ObjectDeActive;
    }

    private bool CheckCanSpawn(Vector2Int v2) 
    {
        foreach(ISpawnObject obj in objectInField)
        {
            if (v2 == obj.GetCurrentPosition()) return false;
        }

        return true;
    }

    private void ObjectDeActive(ISpawnObject obj)
    {
        objectInField.Remove(obj);
    }
}
