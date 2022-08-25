using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paintastic.Player
{
    public class Player : MonoBehaviour
    {
        public event System.Action<Material,string> OnCollideWithGrid;
        [SerializeField] private Material playerMaterial;
        //[SerializeField] private string playerTag;
        private void Awake()
        {
            Color color;
            if (PlayerPrefs.GetString("Player") == tag)
            {
                ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("Player"), out color);
                playerMaterial.color = color;
            }
        }
        private void Start()
        {
            gameObject.GetComponent<MeshRenderer>().material = playerMaterial;
            gameObject.tag = gameObject.tag;
        }
        private void Update()
        {
            OnCollideWithGrid?.Invoke(playerMaterial, gameObject.tag);
        }
    }

}
