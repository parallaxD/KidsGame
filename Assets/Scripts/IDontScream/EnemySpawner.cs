using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private Collider2D spawnAreaCollider;

    private void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        if (spawnAreaCollider == null) return;

        Vector2 randomPoint = GenerateRandomPoint(spawnAreaCollider.bounds);

        GameObject newEnemy = Instantiate(EnemyPrefab, randomPoint, Quaternion.identity);

        WaveController.Enemies.Add(newEnemy);

    }

    private Vector2 GenerateRandomPoint(Bounds bounds)
    {
        return new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y));
    }
}
