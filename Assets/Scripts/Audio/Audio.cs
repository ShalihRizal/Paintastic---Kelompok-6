using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Audio : MonoBehaviour
{
	[SerializeField]
	private string _name;
	[SerializeField]
	private AudioClip audioClip;
	[SerializeField]
	private bool bgmON;
	[SerializeField]
	private string typeAudio;

	private AudioSource audioSource;

	public string Name => _name;
	public AudioClip AudioClip => audioClip;
	public bool BgmOn => bgmON;
	public string TypeAudio => typeAudio;
	public AudioSource AudioSource
	{
		get {return audioSource;}
		set {audioSource = value;}
	}
}
