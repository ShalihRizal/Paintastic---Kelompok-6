using UnityEngine;
using UnityEngine.UI;

public class SkyboxChanger : MonoBehaviour
{
    [SerializeField]
    private Material[] skyboxes;

    private void Awake()
    {
        ChangeSkybox();
    }

    void ChangeSkybox()
    {
        RenderSettings.skybox = skyboxes[GetRandomNumber(0, skyboxes.Length-1)];
    }

    int GetRandomNumber(int min, int max)
    {
        return Random.Range(min, max);
    }

}
