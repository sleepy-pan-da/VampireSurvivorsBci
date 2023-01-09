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
    [SerializeField]
    private List<SpawnInfo> spawnInfoList;

    private void Start()
    {
        PlayerStatsManager.OnDeath += StopSpawning;
        // StartSpawning();
        StartCoroutine(StartSpawnWave());
    }

    // For debugging
    private void StartSpawning()
    {
        InvokeRepeating("SpawnEnemy", 0f, 1f);
    }

    private void StopSpawning()
    {
        CancelInvoke();
        StopAllCoroutines();
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnArea.x/2, spawnArea.x/2),Random.Range(-spawnArea.y/2, spawnArea.y/2), 0);
        SpawnIndicator newSpawnIndicator = Instantiate(spawnIndicator, spawnPosition, transform.rotation, parent);
        newSpawnIndicator.EnemySpawned = enemy;
        newSpawnIndicator.Parent = parent;
        newSpawnIndicator.Pickups = pickups;
    }

    private void SpawnEnemy(GameObject enemyType, int spawnQty)
    {
        for (int _=0; _<spawnQty; _++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnArea.x/2, spawnArea.x/2),Random.Range(-spawnArea.y/2, spawnArea.y/2), 0);
            SpawnIndicator newSpawnIndicator = Instantiate(spawnIndicator, spawnPosition, transform.rotation, parent);
            newSpawnIndicator.EnemySpawned = enemyType;
            newSpawnIndicator.Parent = parent;
            newSpawnIndicator.Pickups = pickups;
        }
        
    }

    private IEnumerator StartSpawnWave()
    {   
        foreach (SpawnInfo spawnInfo in spawnInfoList)
        {
            yield return new WaitForSeconds(spawnInfo.TimeTakenToSpawn);
            for (int i=0; i<spawnInfo.EnemyTypes.Count; i++)
            {
                SpawnEnemy(spawnInfo.EnemyTypes[i], spawnInfo.SpawnQty[i]);
            }
        }
        Debug.Log("Finished all spawnwaves!");
    }
}
