using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnIndicator;
    [SerializeField]
    private GameObject enemy;
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
        GameObject newSpawnIndicator = Instantiate(spawnIndicator, spawnPosition, transform.rotation);
        newSpawnIndicator.GetComponent<SpawnIndicator>().EnemySpawned = enemy;
    } 
}
