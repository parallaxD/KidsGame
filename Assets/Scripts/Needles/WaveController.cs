using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WaveController : MonoBehaviour
{
    public static List<GameObject> Enemies = new List<GameObject>();
    public static int KillsCount = 0;

    [SerializeField] private EnemySpawner _enemySpawner;

    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _blackBackGround;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private ProgressBar _progressBar;

    public bool IsEndlessGame;


    float spawnRate = 1.0f;
    float lastSpawnTime;


    private void FixedUpdate()
    {
        if (!IsEndlessGame)
        {
            if (KillsCount >= 10)
            {
                _winPanel.SetActive(true);
                GameManager.IsGamePaused = true;
                _blackBackGround.SetActive(true);
            }
        }
        print(KillsCount);
        if (Enemies.Count == 0 && !GameManager.IsGamePaused) _enemySpawner.SpawnEnemy();
        lastSpawnTime += Time.deltaTime;
    }

    public void ResetKills()
    {
        Enemies.Clear();
        KillsCount = 0;
        _progressBar.CurrentValue = 0;
        _scoreText.text = $"0/10";
    }
}
