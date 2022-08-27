using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScritptableObjectAudio : ScriptableObject
{
    [SerializeField]
	private string menuBGM;
	[SerializeField]
	private string gamePlayBGM;

	[SerializeField]
	private Audio[] audio;

	public string MenuBGM => menuBGM;
	public string GameplayBGM => gamePlayBGM;

	public Audio[] GetAudio()
    {
		Audio[] tempAudio = new Audio[audio.Length];
		System.Array.Copy(audio, tempAudio, audio.Length);
		return tempAudio;
    }
}
