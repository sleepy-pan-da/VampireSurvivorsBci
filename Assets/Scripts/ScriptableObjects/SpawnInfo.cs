using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnInfo")]
public class SpawnInfo : ScriptableObject
{
    public int TimeTakenToSpawn;
    public List<GameObject> EnemyTypes;
    public List<int> SpawnQty;
}
