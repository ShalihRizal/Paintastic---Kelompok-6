using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerController anotherPlayer = null;
    private Transform[,] path = new Transform[8, 8];
    private Vector2Int current = new Vector2Int();
    private Vector2Int target = new Vector2Int();

    public void SetInit(PlayerController anotherPlayer, Transform[,] path, Vector2Int spawnPoint)
    {
        this.anotherPlayer = anotherPlayer;
        this.path = path;
        current = spawnPoint;

        transform.position = path[current.x, current.y].position;
    }

    private void Update()
    {
        PlayerJump();
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
        if (transform.position.y < 3) return;
        if (current + target == anotherPlayer.GetPlayerPos()) return;

        current += target;
        target = Vector2Int.zero;

        if (transform.position.x != path[current.x, current.y].position.x || transform.position.z != path[current.x, current.y].transform.position.z)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(path[current.x, current.y].position.x, transform.position.y, path[current.x, current.y].position.z), 1f);
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