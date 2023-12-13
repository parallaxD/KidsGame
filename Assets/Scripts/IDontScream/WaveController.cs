using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public static List<GameObject> Enemies = new List<GameObject>();
    public static int KillsCount = 0;

    [SerializeField] private EnemySpawner _enemySpawner;


    private void FixedUpdate()
    {
        if (Enemies.Count == 0 && !GameManager.IsGamePaused) _enemySpawner.SpawnEnemy();
    }
}
