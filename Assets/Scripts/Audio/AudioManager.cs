using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [Range(0f, 1f)]
    public float currentVolumeMusic;
    [Range(0f, 1f)]
    public float currentVolumeSound;
    [Header("------------------Sfx-------------------------")]
    public AudioClip[] sfx;

    public AudioSource pickAudioSource;
    public AudioSource actionAudioSource;

    void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

    }

    public void PlaySfx(string key)
    {
        if (key == "jump")
        {
            actionAudioSource.clip = sfx[1];
            actionAudioSource.Play();
        }
        else if (key == "dash")
        {
            actionAudioSource.clip = sfx[0];
            actionAudioSource.Play();
        }
        else if (key == "die")
        {
            actionAudioSource.clip = sfx[2];
            actionAudioSource.Play();
        }
        else if (key == "collect")
        {
            pickAudioSource.clip = sfx[3];
            pickAudioSource.Play();
        }
        else if (key == "kill")
        {
            pickAudioSource.clip = sfx[4];
            pickAudioSource.Play();
        }
    }
}
