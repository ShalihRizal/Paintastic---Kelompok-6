using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    public Action<SettingConfig> OnSaveConfig;
    public Action<SettingConfig> OnLoadConfig;

    [Header("SoundSetting")]
    [SerializeField]
    private Image muteButtonSprite;
    [SerializeField]
    private Image unMuteButtonSprite;
    [SerializeField]
    private AudioMixer _bgmMixer;
    [SerializeField]
    private AudioMixer _sfxMixer;
   
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    private SettingConfig currentData;
    private void Start()
    {
        StartCoroutine(LoadDataConfig());
    }

    public void SetMute()
    {
        currentData.IsMute = !currentData.IsMute;
    }

    public void SetBGMVolume(float volume)
    {
        _bgmMixer.SetFloat("Volume", volume);
        currentData.BgmVolume = volume;
    }

    public void SetSfXVolume(float volume)
    {
        _sfxMixer.SetFloat("Volume", volume);
        currentData.SfxVolume = volume;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        currentData.QualityIndex = qualityIndex;
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        currentData.IsFullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        currentData.ResolutionIndex = resolutionIndex;
    }

    public void OnCloseOptionPanel()
    {
        OnSaveConfig(currentData);
    }

    private IEnumerator LoadDataConfig()
    {
        currentData = new SettingConfig();
        currentData.isDoneLoad = false;

        OnLoadConfig(currentData);

        yield return new WaitUntil(() => currentData.isDoneLoad);

        if (currentData.isNewData)
        {
            resolutions = Screen.resolutions;

            resolutionDropdown.ClearOptions();

            List<string> options = new List<string>();

            int currentResolutionIndex = 0;

            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);

                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }

            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();
        }
    }
}
