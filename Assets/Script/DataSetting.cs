using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    private void LoadSettingConfig(SettingConfig data)
    {
        string json = PlayerPrefs.GetString("SettingConfig");
        if (string.IsNullOrWhiteSpace(json))
            data.SetAllValue(new SettingConfig());
        else 
            data.SetAllValue(JsonUtility.FromJson<SettingConfig>(json));
    }
}

[System.Serializable]
public class SettingConfig
{
    public float BgmVolume;
    public float SfxVolume;
    public bool IsMute;

    public int QualityIndex;
    public int ResolutionIndex;
    public bool IsFullScreen;

    public bool isNewData = true;
    public bool isDoneLoad = false;

    public void SetAllValue(SettingConfig data)
    {
        BgmVolume = data.BgmVolume;
        SfxVolume = data.SfxVolume;
        IsMute = data.IsMute;

        QualityIndex = data.QualityIndex;
        ResolutionIndex = data.ResolutionIndex;
        IsFullScreen = data.IsFullScreen;

        isNewData = data.isNewData;
        isDoneLoad = true;
    }

}