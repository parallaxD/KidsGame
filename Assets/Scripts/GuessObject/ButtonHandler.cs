using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    private ButtonData _buttonData;

    private ResultHandler _resultHandler;
    private UIController _uiController;


    private void Start()
    {
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

        _uiController.UpdateScoreText(_resultHandler.CurrentScore);
    }
}
