using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsSetter : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _volumeSlider;

    public void SetVolume(float value)
    {
        _audioMixer.SetFloat("Volume", Mathf.Log10(value) * 30);
    }

    private void SaveVolumeSetting()
    {
        PlayerPrefs.SetFloat("VolumePreference", _volumeSlider.value);
    }
}
    