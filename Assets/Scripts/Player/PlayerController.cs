using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerController anotherPlayer = null;
    private Transform[,] path = new Transform[8, 8];
    private Vector2Int current = new Vector2Int();
    private Vector2Int target = new Vector2Int();
    private float walkDelay=.15f, tmpTime=0;

    public void SetInit(PlayerController anotherPlayer, GameObject[,] path, Vector2Int spawnPoint)
    {
        this.anotherPlayer = anotherPlayer;
        //this.path = path;
        for(int i =0; i<path.GetLength(0);i++)
        {
            for (int j = 0; j < path.GetLength(1); j++)
            {
                this.path[i, j] = path[i, j].transform;
            }
        }
        current = spawnPoint;

        transform.position = this.path[current.x, current.y].position;
        //transform.position = new Vector3(this.path[current.x, current.y].position.x, 10f, this.path[current.x, current.y].position.y);
    }

    private void Update()
    {
        //PlayerJump();
        PlayerMove();
    }

    private void PlayerJump()
    {
        if (transform.position.y <= 1) transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 3, transform.position.z), 1f);
        else transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 1, transform.position.z),
            0.1f / Vector3.Distance(transform.position, new Vector3(transform.position.x, 1, transform.position.z)));
    }

    private void PlayerMove()
    {
        /*if (transform.position.y < 3) return;
        if (current + target == anotherPlayer.GetPlayerPos()) return;

        current += target;
        target = Vector2Int.zero;

        if (transform.position.x != path[current.x, current.y].position.x || transform.position.z != path[current.x, current.y].transform.position.z)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(path[current.x, current.y].position.x, transform.position.y, path[current.x, current.y].position.z), 1f);
        }*/
        tmpTime += Time.deltaTime;
        if (tmpTime > walkDelay)
        {
            if (current + target == anotherPlayer.GetPlayerPos()) return;

            current += target;
            target = Vector2Int.zero;
            transform.position = Vector3.Lerp(transform.position, new Vector3(path[current.x, current.y].position.x, transform.position.y, path[current.x, current.y].position.z), 1f);
            //transform.position = new Vector3(target.x, target.y, transform.position.z);
            tmpTime = 0;
        }
    }

    public void PlayerDir(Vector2Int dir)
    {
        if (current.x + dir.x < 0 || current.x + dir.x >= path.GetLength(0)
            || current.y + dir.y < 0 || current.y + dir.y >= path.GetLength(1)) return;

        target = dir;
    }

    public Vector2Int GetPlayerPos() => current;
}
