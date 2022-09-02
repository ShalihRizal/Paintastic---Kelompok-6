using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paintastic.Setting
{
    public class DataSetting : MonoBehaviour
    {
        [SerializeField]
        private SettingsManager settingManager;

        private void OnEnable()
        {
            settingManager.OnSaveConfig += SaveSettingConfig;
            settingManager.OnLoadConfig += LoadSettingConfig;
        }

        private void OnDisable()
        {
            settingManager.OnSaveConfig -= SaveSettingConfig;
            settingManager.OnLoadConfig -= LoadSettingConfig;
        }

        private void SaveSettingConfig(SettingConfig data)
        {
            data.isNewData = false;
            PlayerPrefs.SetString("SettingConfig", JsonUtility.ToJson(data));

            Debug.Log("Xcute");
        }

        private void LoadSettingConfig(SettingConfig data)
        {
            string json = PlayerPrefs.GetString("SettingConfig");

            Debug.Log(json);
            if (string.IsNullOrWhiteSpace(json))
                data.SetAllValue(new SettingConfig());
            else
                data.SetAllValue(JsonUtility.FromJson<SettingConfig>(json));
        }
    }

    [System.Serializable]
    public class SettingConfig
    {
        public float BgmVolume = 1;
        public float SfxVolume = 1;
        public bool IsMute = false;

        public int QualityIndex = 0;
        public Vector2Int ScreenResolution;
        public bool IsFullScreen = true;

        public bool isNewData = true;
        public bool isDoneLoad = false;

        public void SetAllValue(SettingConfig data)
        {
            BgmVolume = data.BgmVolume;
            SfxVolume = data.SfxVolume;
            IsMute = data.IsMute;

            QualityIndex = data.QualityIndex;
            ScreenResolution = data.ScreenResolution;
            IsFullScreen = data.IsFullScreen;

            isNewData = data.isNewData;
            isDoneLoad = true;
        }

    }
}