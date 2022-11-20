using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject basicEnemy;
    [Header("X and Y refers to width and height")]

    [SerializeField]
    private Vector2 spawnArea;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, 1f);
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnArea.x/2, spawnArea.x/2),Random.Range(-spawnArea.y/2, spawnArea.y/2), 0);
        Instantiate(basicEnemy, spawnPosition, transform.rotation);
    } 
}
