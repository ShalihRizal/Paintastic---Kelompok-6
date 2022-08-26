using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    BGM bgm;

    public static event Action playSFX;
    public static event Action playBGM;

    public void PlaySFX()
    {
        playSFX?.Invoke();
    }
    public void Awake()
    {
        playBGM?.Invoke();
    }

}
