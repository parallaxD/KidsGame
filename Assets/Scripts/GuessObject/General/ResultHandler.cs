using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultHandler : MonoBehaviour
{

    [SerializeField] ProgressBar _progressBarScript;
    [SerializeField] GameObject _winPanel;
    [SerializeField] private int _maxIterationsCount;
    [SerializeField] private List<GameObject> _stars;
    [SerializeField] private SoundManager _soundManager;

    private int _curentIterationsCount = 1;
    public static int CurrentScore { get; set; }

    private void Start()
    {
        CurrentScore = 0;
    }

    public void IncreaseScore()
    {
        if (CheckGameEnd() || CurrentScore == 10)
        {
            _soundManager.PlayWinSound();
            _winPanel.SetActive(true);
            for (int i = 0; i < GetStarsCount(); i++)
            {
                _stars[i].SetActive(true);
            }
        }

        _curentIterationsCount++;

        if (CurrentScore + 1 <= _progressBarScript.MaximumValue)
        {
            _progressBarScript.IncreaseCurentValue();
            CurrentScore = _progressBarScript.CurrentValue;
        }
    }

    public void DecreaseScore()
    {
        if (CheckGameEnd())
        {
            _soundManager.PlayWinSound();
            _winPanel.SetActive(true);
            for (int i = 0; i < GetStarsCount(); i++)
            {
                _stars[i].SetActive(true);
            }
        }
        _curentIterationsCount++;

        if (CurrentScore - 1 > 0)
        {
            _progressBarScript.DecreaseCurentValue();
            CurrentScore = _progressBarScript.CurrentValue;
        }
    }

    private bool CheckGameEnd()
    {
        if (_curentIterationsCount == _maxIterationsCount)
        {
            return true;
        }
        return false;
    }

    private int GetStarsCount()
    {
        if (CurrentScore > 0 && CurrentScore <= 10)
        {
            return (int)Math.Ceiling(CurrentScore / 2.0);
        }
        else
        {
            return 0;
        }
    }

    public void Reset()
    {
        foreach (var star in _stars)
        {
            star.SetActive(false);
        }
        _curentIterationsCount = 1;
        CurrentScore = 0;
    }
}
