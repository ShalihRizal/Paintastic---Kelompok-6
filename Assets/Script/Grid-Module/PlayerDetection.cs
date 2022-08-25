using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.Player;
using System;

namespace Paintastic.GridSystem
{
    public class PlayerDetection : MonoBehaviour
    {
        public event System.Action<GameObject> OnCollectPointPicked;

        private void OnCollisionEnter(Collision collision)
        {
            if (!CompareTag("CollectPoint"))
            {
                collision.gameObject.GetComponent<Player.Player>().OnCollideWithGrid += OnCollideWithGrid;
            }
            else
            {
                OnCollectPointPicked?.Invoke(collision.gameObject);
                collision.gameObject.GetComponent<Player.Player>().OnCollideWithGrid += OnCollideWithGrid;
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            collision.gameObject.GetComponent<Player.Player>().OnCollideWithGrid -= OnCollideWithGrid;
            
        }

        private void OnCollideWithGrid(Material arg1, string arg2)
        {
            gameObject.GetComponent<MeshRenderer>().material = arg1;
            gameObject.tag = arg2;
        }

    }
}
