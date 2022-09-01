using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPropertyBlock : MonoBehaviour
{
    private GameObject go;
    private Material material;
    [SerializeField]
    private Color color;
    [SerializeField]
    private Texture baseMap;
    [SerializeField, Range(0f,1f)] private float metallic = 0f;
    [SerializeField, Range(0f, 1f)] private float smoothness = .5f;

    void Start()
    {
        go = this.gameObject;
        material = go.GetComponent<MeshRenderer>().material;
        material.color = color;
        if (baseMap != null)
        {
            material.SetTexture("_BaseMap", baseMap);
        }
        material.SetFloat("_Metallic", metallic);
        material.SetFloat("_Smoothness", smoothness);
    }

}
