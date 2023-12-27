using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedlesUIController : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;


    public void ShowGameOverPanel()
    {
        _gameOverPanel.SetActive(true);
    }
}
