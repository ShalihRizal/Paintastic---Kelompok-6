using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioManager : MonoBehaviour
{
	private Audio[] audios;
	public static AudioManager instance { get; private set;}

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

		foreach(Audio _audio in audios)
		{
			_audio.AudioSource = gameObject.AddComponent<AudioSource>();
		}
	}
}
