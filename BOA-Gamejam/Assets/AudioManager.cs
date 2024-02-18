using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioClip mainMusic;
    [SerializeField] AudioClip music30s;
    [SerializeField] AudioClip mainMusicLoop;

    private void Start()
    {
        musicSource.clip = mainMusic;
        musicSource.Play();
    }
}
