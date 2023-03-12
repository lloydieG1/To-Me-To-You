using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnRadius = 10f;
    public float offsetY = -2f;

    private float timeSinceLastSpawn;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f;
        }
    }

    void SpawnEnemy()
    {
        // Vector2 randomSpawnPoint = transform.position + Random.insideUnitSphere * spawnRadius;

        Vector2 spawnPoint = new Vector2(transform.position.x, transform.position.y + offsetY);

        Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
    }
}

