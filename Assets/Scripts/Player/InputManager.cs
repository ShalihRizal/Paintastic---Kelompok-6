using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paintastic.Player
{
    public class InputManager : MonoBehaviour
    {
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

            GetComponent<PlayerMovement>().PlayerDir(dir);
        }
    }

}
