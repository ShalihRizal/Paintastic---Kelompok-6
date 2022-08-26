using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScritptableObjectAudio : ScriptableObject
{
    [SerializeField]
	private string menuBGM;
	private string gamePlayBGM;

	[SerializeField]
	private Audio[] audio;

	public string MenuBGM => menuBGM;
	public string GameplayBGM => gamePlayBGM;
}
