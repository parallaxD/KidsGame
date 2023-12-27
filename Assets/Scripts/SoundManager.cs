using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class SoundManager : MonoBehaviour
{

    private AudioSource _audioSource;

    public static AudioMixerGroup OutputMixer;

    [SerializeField] private AudioClip _winSound;
    [SerializeField] private AudioClip _loseSound;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        OutputMixer = _audioSource.outputAudioMixerGroup;
    }

    public void PlayWinSound()
    {
        AudioSource.PlayClipAtPoint(_winSound, Camera.main.transform.position);
    }

    public void PlayLoseSound()
    {
        AudioSource.PlayClipAtPoint(_loseSound, Camera.main.transform.position);
    }
}
