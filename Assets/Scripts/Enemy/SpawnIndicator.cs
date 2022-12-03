using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Animation))]
public class SpawnIndicator : MonoBehaviour
{
    [HideInInspector]
    public GameObject EnemySpawned;
    
    void Start()
    {
        GetComponent<Animation>().Play();
    }

    public void FinishedAnimation()
    {
        Instantiate(EnemySpawned, transform.position, transform.rotation);
    }

}
