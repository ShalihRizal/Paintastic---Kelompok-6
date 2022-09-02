using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Paintastic.Skyboxes
{
    public class SkyboxChanger : MonoBehaviour
    {
        [SerializeField]
        private Material[] skyboxes;

        [SerializeField]
        float interval = 10f;

        [SerializeField]
        private int index = 0;

        private void Start()
        {
            InvokeRepeating("WaitAndChangeSkybox", 0, interval);
        }

        void WaitAndChangeSkybox()
        {
            RenderSettings.skybox = skyboxes[index];
            index++;
        }

    }
}