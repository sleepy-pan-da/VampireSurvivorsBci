using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveSpecifications : MonoBehaviour
{
    [HideInInspector]
    public Transform skillInstances;
    public abstract void Compute(int level);
    protected bool canSpawn = true;
         
    protected IEnumerator SpawnAfterSeconds(float seconds)
    {
        while (canSpawn)
        {
            yield return new WaitForSeconds(seconds * PlayerStatsManager.Stats.CooldownReduction);
            Spawn();
        }
    } 

    protected virtual void Spawn()
    {

    }
}
