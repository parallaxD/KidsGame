
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class FPSText : MonoBehaviour
{
    private float _fps;
    private  TextMeshProUGUI _fpsText;

    private void Start()
    {
        _fpsText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(FramesPerSecond());
    }

    private IEnumerator FramesPerSecond()
    {
        while (true)
        {
            _fps = (int) (1f / Time.deltaTime);
            PrintFPS(_fps);
 
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void PrintFPS(float fps)
    {
        _fpsText.text = $"FPS: {_fps}";
    }
}
