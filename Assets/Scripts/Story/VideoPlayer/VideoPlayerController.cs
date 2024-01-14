using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    [SerializeField] VideoPlayer _videoPlayer;
    [SerializeField] GameObject _videoCanvas;
    [SerializeField] private GameObject _mainCanvas;
    void Start()
    {
        if (StoryManager.StoryPart != 1)
        {
            _videoPlayer.enabled = false;
            _videoCanvas.SetActive(false);
        }
        _videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer videoPlayer)
    {
        _videoCanvas.SetActive(false);
        _mainCanvas.SetActive(true);
    }
}
