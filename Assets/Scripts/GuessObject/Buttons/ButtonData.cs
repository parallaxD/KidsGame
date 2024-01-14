using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonData : MonoBehaviour
{
    public bool IsRightAnswer;

    public AudioClip _incorrectSound;



    private void Awake()
    {
        IsRightAnswer = false;
        if (gameObject.GetComponent<Button>() == null)
        {
            gameObject.AddComponent<Button>();
        }

        var audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = _incorrectSound;
        audioSource.outputAudioMixerGroup = SoundManager.OutputMixer;
    }





}
