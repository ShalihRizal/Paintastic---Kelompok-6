using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    [SerializeField]
    AudioClip[] bgm;

    private AudioSource bgmSource;

    void Start()
    {
        bgmSource = GetComponent<AudioSource>();
    }

}
