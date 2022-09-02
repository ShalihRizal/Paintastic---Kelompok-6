using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paintastic.Player
{
    [System.Serializable]
    public struct PlayerMaterialBlock
    {
        public int propertyId;
        public int indexUnlock;
        public Color color;
        public Texture baseMap;
        [Range(0f, 1f)] public float metallic;
        [Range(0f, 1f)] public float smoothness;

        /*public void SetTexture(GameObject _targetObject, Material _targetMaterial)
        {
            go = _targetObject.gameObject;
            material = _targetMaterial;
            material.color = color;
            if (baseMap != null)
            {
                material.SetTexture("_BaseMap", baseMap);
            }
            material.SetFloat("_Metallic", metallic);
            material.SetFloat("_Smoothness", smoothness);
        }*/
    }

}
