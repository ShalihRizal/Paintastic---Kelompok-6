using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paintastic.Player
{
    public class Player : MonoBehaviour
    {
        public event System.Action<Material, string> OnCollideWithGrid;
        public event System.Action<string, int> OnSendScore;
        [SerializeField] private GameObject playerObject;
        [SerializeField] private ScriptableMaterialBlock colorMaterialBlock;
        private Material playerMaterial;
        public int LOOKTHIS;

        private float timeBetweenCollectPoint = 10;
        private void Awake()
        {
            LOOKTHIS = PlayerPrefs.GetInt(gameObject.tag + "Color");
            playerMaterial = playerObject.GetComponent<MeshRenderer>().material;
            //Color color;

            /*if (!string.IsNullOrWhiteSpace(PlayerPrefs.GetString(gameObject.tag + "Color")))
            {
                //Debug.Log(PlayerPrefs.GetString(gameObject.tag + "Color"));
                ColorUtility.TryParseHtmlString(PlayerPrefs.GetString(gameObject.tag + "Color"), out color);
                playerMaterial.color = color;
            }*/
            SetTexture(playerObject, playerMaterial, PlayerPrefs.GetInt(gameObject.tag + "Color"));

        }
        private void Start()
        {
            playerObject.GetComponent<MeshRenderer>().material = playerMaterial;
            gameObject.tag = gameObject.tag;
        }
        private void Update()
        {
            timeBetweenCollectPoint += Time.deltaTime;

            OnCollideWithGrid?.Invoke(playerMaterial, gameObject.tag);
        }


        public void SendMyScore(int score)
        {
            if (timeBetweenCollectPoint < 7) score *= 2;

            timeBetweenCollectPoint = 0;
            OnSendScore(tag, score);
        }

        public void SetTexture(GameObject _targetObject, Material _targetMaterial, int id)
        {
            PlayerMaterialBlock currentBlock = colorMaterialBlock.materialProperty[GetIndexOfId(colorMaterialBlock,id)];
            /*GameObject go = _targetObject.gameObject;
            Material material = _targetMaterial;*/
            _targetMaterial.color = currentBlock.color;
            if (currentBlock.baseMap != null)
            {
                _targetMaterial.SetTexture("_BaseMap", currentBlock.baseMap);
            }
            _targetMaterial.SetFloat("_Metallic", currentBlock.metallic);
            _targetMaterial.SetFloat("_Smoothness", currentBlock.smoothness);
        }

        public int GetIndexOfId(ScriptableMaterialBlock block, int value)
        {
            foreach(PlayerMaterialBlock p in block.materialProperty)
            {
                if (p.propertyId == value)
                {
                    return block.materialProperty.IndexOf(p);
                }
            }
            return 0;
        }
    }
}
