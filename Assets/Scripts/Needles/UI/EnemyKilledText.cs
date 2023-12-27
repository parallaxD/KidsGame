using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyKilledText : MonoBehaviour
{
    private float _killsCount;
    private TextMeshProUGUI _enemyKilledText;


    void Start()
    {
        _enemyKilledText = GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate() // Temporarily method
    {
        _enemyKilledText.text = $"!temporarily! EnemiesKilled: {WaveController.KillsCount}";
    }
}
