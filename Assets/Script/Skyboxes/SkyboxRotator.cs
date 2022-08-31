using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotator : MonoBehaviour
{
    public float RotationPerSecond = 1;

    [SerializeField]
    private bool rotate = true;

    void Update()
    {
        if (rotate)
        {
            RenderSettings.skybox.SetFloat("_Rotation", Time.time * RotationPerSecond);
        }
    }
}
