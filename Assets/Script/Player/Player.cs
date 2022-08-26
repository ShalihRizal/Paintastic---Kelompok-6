using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paintastic.Player
{
    public class Player : MonoBehaviour
    {
        public event System.Action<Material, string> OnCollideWithGrid;
        public event System.Action<string, int> OnSendScore;
        [SerializeField] private Material playerMaterial;
        [SerializeField] private GameObject playerObject;
        private void Awake()
        {
            Color color;

            if (!string.IsNullOrWhiteSpace(PlayerPrefs.GetString(gameObject.tag + "Color")))
            {
                //Debug.Log(PlayerPrefs.GetString(gameObject.tag + "Color"));
                ColorUtility.TryParseHtmlString(PlayerPrefs.GetString(gameObject.tag + "Color"), out color);
                playerMaterial.color = color;
            }

        }
        private void Start()
        {
            playerObject.GetComponent<MeshRenderer>().material = playerMaterial;
            gameObject.tag = gameObject.tag;
        }
        private void Update()
        {
            OnCollideWithGrid?.Invoke(playerMaterial, gameObject.tag);
        }


        public void SendMyScore(int score)
        {
            OnSendScore(tag, score);
        }

    }
}
