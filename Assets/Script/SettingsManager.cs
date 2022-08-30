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
    private Sprite onMuteButtonSprite;
    [SerializeField]
    private Sprite onUnMuteButtonSprite;
    [SerializeField]
    private AudioMixer _bgmMixer;
    [SerializeField]
    private AudioMixer _sfxMixer;

    [Header("UI")]
    [SerializeField]
    private Button _muteButton;
    [SerializeField]
    private Slider _bgmSlider;
    [SerializeField]
    private Slider _sfxSlider;
    [SerializeField]
    private Toggle _fullScreen;

    [Header("Resolution")]
    [SerializeField] private TMP_Dropdown _resolutionDropdown;
    [SerializeField] private TMP_Dropdown _qualityDropdown;
    Resolution[] resolutions;

    private SettingConfig currentData;
    private void Start()
    {
        StartCoroutine(LoadDataConfig());
    }

    private void SetMute()
    {
        currentData.IsMute = !currentData.IsMute;
        SetMuteButtonSprite();
    }

    private void SetBGMVolume(float volume)
    {
        _bgmMixer.SetFloat("Volume", ConvertFloatToVolume(volume));
        currentData.BgmVolume = volume;
    }

    private void SetSfXVolume(float volume)
    {
        _sfxMixer.SetFloat("Volume", ConvertFloatToVolume(volume));
        currentData.SfxVolume = volume;
    }

    private float ConvertFloatToVolume(float v) => Mathf.Log10(v) * 20;

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        currentData.QualityIndex = qualityIndex;
    }

    private void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        currentData.IsFullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        currentData.ScreenResolution = new Vector2Int(resolution.width, resolution.height);
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
            LoadResolution(Screen.currentResolution.width, Screen.currentResolution.height);
        }
        else
        {
            LoadResolution(currentData.ScreenResolution.x, currentData.ScreenResolution.y);
        }

        SetMuteButtonSprite();

        _bgmSlider.value = currentData.BgmVolume;
        _sfxSlider.value = currentData.SfxVolume;

        SetBGMVolume(currentData.BgmVolume);
        SetSfXVolume(currentData.SfxVolume);

        _fullScreen.isOn = currentData.IsFullScreen;
        SetFullScreen(currentData.IsFullScreen);

        _qualityDropdown.value = currentData.QualityIndex;

        _muteButton.onClick.AddListener(SetMute);
        _bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        _sfxSlider.onValueChanged.AddListener(SetSfXVolume);
        _fullScreen.onValueChanged.AddListener(SetFullScreen);
    }

    private void LoadResolution(int screenWidth, int screenHeight)
    {
        resolutions = Screen.resolutions;

        _resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == screenWidth && resolutions[i].height == screenHeight)
            {
                currentResolutionIndex = i;
            }
        }

        _resolutionDropdown.AddOptions(options);
        _resolutionDropdown.value = currentResolutionIndex;
    }

    private void SetMuteButtonSprite()
    {
        AudioManager.instance.SetMute(currentData.IsMute);

        _muteButton.GetComponent<Image>().sprite =
            currentData.IsMute ? onMuteButtonSprite : onUnMuteButtonSprite;
    }
}
