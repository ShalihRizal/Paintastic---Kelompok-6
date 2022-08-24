using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    /*[Header("Player")]
    [SerializeField] private PlayerController player;*/

    [Header("Direction")]
    [SerializeField] private KeyCode forward;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode back;
    [SerializeField] private KeyCode left;

    private void Update()
    {
        GetDirection();
    }

    private void GetDirection()
    {
        Vector2Int dir = new Vector2Int();
        if (Input.GetKey(forward)) dir = Vector2Int.up;
        else if (Input.GetKey(right)) dir = Vector2Int.right;
        else if (Input.GetKey(left)) dir = Vector2Int.left;
        else if (Input.GetKey(back)) dir = Vector2Int.down;

        GetComponent<PlayerController>().PlayerDir(dir);
    }
}
