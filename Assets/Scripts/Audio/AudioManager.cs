using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	private Audio[] audios;
	[SerializeField]
	ScritptableObjectAudio savedAudio;

	[SerializeField]
	LevelManager levelManager;

	[SerializeField]
	private AudioMixerGroup _bgmMixer;
	[SerializeField]
	private AudioMixerGroup _sfxMixer;

	private bool isMute = false;

	public static AudioManager instance { get; private set;}

    private void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
        levelManager.OnChangeScene += CheckBGM;
    }
    private void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy (gameObject);
			return;
		}
		else
		{
			instance = this;
		}
		audios = new Audio[savedAudio.GetAudio().Length];
		System.Array.Copy(savedAudio.GetAudio(), audios, audios.Length);

		foreach(Audio _audio in audios)
		{
			_audio.AudioSource = gameObject.AddComponent<AudioSource>();
			InitializeAudio(_audio);
		}
		CheckBGM(SceneManager.GetActiveScene().name);
	}
	private void InitializeAudio(Audio audio)
    {
		audio.AudioSource.clip = audio.AudioClip;
		audio.AudioSource.volume = 0.6f;
		audio.AudioSource.loop = audio.BgmOn;
		audio.AudioSource.playOnAwake = false;

		switch (audio.TypeAudio)
        {
			case "BGM":
				audio.AudioSource.outputAudioMixerGroup = _bgmMixer;
				break;
			case "SFX":
				audio.AudioSource.outputAudioMixerGroup = _sfxMixer;
				break;
        }
    }
	private void CheckBGM(string sceneName)
    {
		if (sceneName == "MainMenu")
        {
			PlayBgm(savedAudio.MenuBGM);
        }
		else
        {
			PlayBgm(savedAudio.GameplayBGM);
        }
    }
	public void PlayBgm(string bgmName)
    {
		if (isMute) return;

		Audio searchBGM = System.Array.Find(audios, audio => audio.Name == bgmName && audio.BgmOn);

		if (searchBGM?.AudioSource.isPlaying == true)
        {
			return;
        }
		foreach (Audio a in System.Array.FindAll(audios, audio => audio.BgmOn && audio.AudioSource.isPlaying))
        {
			a.AudioSource.Stop();
        }
		searchBGM?.AudioSource.Play();
    }
	public void PlaySfx(string sfxName)
    {
		if (isMute) return;

		Audio searchSFX = System.Array.Find(audios, audio => audio.Name == sfxName && !audio.BgmOn && !audio.AudioSource.isPlaying);
		if (searchSFX == null)
        {
			searchSFX = (Audio)System.Array.Find(savedAudio.GetAudio(), audio => audio.Name == sfxName);
			InitializeAudio(searchSFX);
			searchSFX.AudioSource.loop = false;
			searchSFX.AudioSource.volume = 1.0f;
			audios = audios.Concat(new Audio[] { searchSFX }).ToArray();
        }
		searchSFX.AudioSource.Play();
	}

	public void SetMute(bool isMute)
	{
		this.isMute = isMute;

		if (this.isMute)
			foreach (Audio a in System.Array.FindAll(audios, audio => audio.BgmOn && audio.AudioSource.isPlaying))
				a.AudioSource.Stop();
		else
			CheckBGM(SceneManager.GetActiveScene().name);
	}
}
