using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Start()
    {
        _scoreText.text = $"Правильных ответов: 0";
    }

    public void UpdateScoreText(int score)
    {
        _scoreText.text = $"Правильных ответов: {score}";
    }
}
