using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.Player;
using System;

namespace Paintastic.GridSystem
{
    public class PlayerDetection : MonoBehaviour
    {
        [SerializeField] private Renderer rend;

        private void OnCollisionEnter(Collision collision)
        {
            collision.gameObject.GetComponent<Player.Player>().OnCollideWithGrid += OnCollideWithGrid;
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

        private void ColorCheck()
        {

        }
    }
}
