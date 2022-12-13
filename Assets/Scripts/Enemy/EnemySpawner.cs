using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private SpawnIndicator spawnIndicator;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private Transform parent;
    [SerializeField]
    private Transform pickups;
    [Header("X and Y refers to width and height")]

    [SerializeField]
    private Vector2 spawnArea;

    private void Start()
    {
        PlayerStatsManager.OnDeath += StopSpawning;
        StartSpawning();
    }

    private void StartSpawning()
    {
        InvokeRepeating("SpawnEnemy", 0f, 1f); 
    }

    private void StopSpawning()
    {
        CancelInvoke();
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnArea.x/2, spawnArea.x/2),Random.Range(-spawnArea.y/2, spawnArea.y/2), 0);
        SpawnIndicator newSpawnIndicator = Instantiate(spawnIndicator, spawnPosition, transform.rotation, parent);
        newSpawnIndicator.EnemySpawned = enemy;
        newSpawnIndicator.parent = parent;
        newSpawnIndicator.pickups = pickups;
    }
}
