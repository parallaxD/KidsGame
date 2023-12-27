using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    private ButtonData _buttonData;

    private ResultHandler _resultHandler;
    private UIController _uiController;
    private AudioSource _audioSource;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _resultHandler = GameObject.Find("ResultHandler").GetComponent<ResultHandler>();

        _uiController = GameObject.Find("UIController").GetComponent<UIController>();

        _buttonData = GetComponent<ButtonData>();

        _buttonData.gameObject.GetComponent<Button>().onClick.AddListener(ButtonClickEvent);
    }

    private void ButtonClickEvent()
    {
        if (_buttonData.IsRightAnswer)
        {
            _resultHandler.IncreaseScore();
           
        }
        else
        {
            _resultHandler.DecreaseScore();
        }

        AudioSource.PlayClipAtPoint(_audioSource.clip, Camera.main.transform.position);

        _uiController.UpdateScoreText(ResultHandler.CurrentScore);
    }
}
