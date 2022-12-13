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
    public Transform parent;
    [HideInInspector]
    public Transform pickups;
    void Start()
    {
        GetComponent<Animation>().Play();
    }

    public void FinishedAnimation()
    {
        GameObject enemy = Instantiate(EnemySpawned, transform.position, transform.rotation, parent);
        enemy.GetComponent<EnemyStatsManager>().pickups = pickups;
        Destroy(gameObject);
    }

}
