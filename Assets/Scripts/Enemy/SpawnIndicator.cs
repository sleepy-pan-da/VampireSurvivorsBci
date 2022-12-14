using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Animation))]
public class SpawnIndicator : MonoBehaviour
{
    [HideInInspector]
    public GameObject EnemySpawned;
    [HideInInspector]
    public Transform Parent;
    [HideInInspector]
    public Transform Pickups;
    void Start()
    {
        GetComponent<Animation>().Play();
    }

    public void FinishedAnimation()
    {
        GameObject enemy = Instantiate(EnemySpawned, transform.position, transform.rotation, Parent);
        enemy.GetComponent<EnemyStatsManager>().Pickups = Pickups;
        Destroy(gameObject);
    }

}
