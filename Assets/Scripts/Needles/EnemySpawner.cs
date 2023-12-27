using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private Collider2D[] _spawnAreaColliders;
    [SerializeField] private Transform _enemyParentObject;
    [SerializeField] private GameObject _player;


    private void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        if (_spawnAreaColliders.Any(x => x == null)) return;

        var randomIndex = Random.Range(0, 2);

        Vector2 randomPoint = GenerateRandomPoint(_spawnAreaColliders[randomIndex].bounds);

        GameObject newEnemy = Instantiate(EnemyPrefab, randomPoint, Quaternion.identity);


        switch (randomIndex)
        {
            case 0:
                newEnemy.transform.rotation = Quaternion.Euler(0f, 0f, 85f);
                break;
            case 1:
                newEnemy.transform.rotation = Quaternion.Euler(0f, 0f, 10f);
                break;
        }

        newEnemy.transform.SetParent(_enemyParentObject);
        newEnemy.transform.SetSiblingIndex(1);

        WaveController.Enemies.Add(newEnemy);
    }

    private Vector2 GenerateRandomPoint(Bounds bounds)
    {
        return new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y));
    }

}
