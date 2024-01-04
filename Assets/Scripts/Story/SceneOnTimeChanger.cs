using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOnTimeChanger : MonoBehaviour
{
    [SerializeField] private float _changeTime;
    [SerializeField] private string _sceneName;
    void Update()
    {
        _changeTime -= Time.deltaTime;
        if (_changeTime <= 0)
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}
