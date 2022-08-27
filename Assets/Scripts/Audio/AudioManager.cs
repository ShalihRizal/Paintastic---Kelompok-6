using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
	private Audio[] audios;
	[SerializeField]
	ScritptableObjectAudio savedAudio;

	LevelManager levelManager;
	public static AudioManager instance { get; private set;}

    private void OnEnable()
    {
		DontDestroyOnLoad(gameObject);
		levelManager.OnChangeScene += CheckBGM;
    }
    /*private void OnDisable()
    {
		levelManager.OnChangeScene -= CheckBGM;
    }*/

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
		audio.AudioSource.volume = 1.0f;
		audio.AudioSource.loop = audio.BgmOn;
		audio.AudioSource.playOnAwake = false;
    }
	private void CheckBGM(string sceneName)
    {
		levelManager = FindObjectOfType<LevelManager>();
		if (sceneName == "MainMenu")
        {
			PlayBgm(savedAudio.MenuBGM);
        }
		else if (sceneName == "ColorSelection")
        {
			PlayBgm(savedAudio.GameplayBGM);
        }
    }
	public void PlayBgm(string bgmName)
    {
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
}
