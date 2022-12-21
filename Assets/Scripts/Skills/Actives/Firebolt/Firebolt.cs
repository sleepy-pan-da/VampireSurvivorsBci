using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebolt : ActiveSpecifications
{
    private HashSet<Transform> nearbyEnemies = new HashSet<Transform>(); 
    [SerializeField]
    private FireboltInstance firebolt;
    private float spawnOffset = 0.5f;
    private int baseDamage = 45;
    private float cooldown = 1.5f;
    private float projectileInterval = 0.1f;
    private float baseSpeed = 7f;
    private float knockbackStrength = 160f;
    private int pierce;
    
    private void Start()
    {
        StartCoroutine(SpawnAfterSeconds(cooldown));
    }

    protected override void Spawn()
    {
        Transform closestEnemy = GetClosestEnemy();
        if (!closestEnemy) return;

        Vector3 direction = (closestEnemy.position - transform.position).normalized;
        FireboltInstance fireboltInstance = Instantiate(firebolt, transform.position + direction * spawnOffset, firebolt.transform.rotation, skillInstances);
        int damage = PlayerStatsManager.Stats.ComputeDamageFromMultiplier(baseDamage);
        
        fireboltInstance.fire(direction, damage, baseSpeed, knockbackStrength);
    }   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            nearbyEnemies.Add(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            nearbyEnemies.Remove(collision.transform);
        }
    }

    private Transform GetClosestEnemy()
    {
        Transform bestTarget = null;
        float closestDistSqr = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform potentialTarget in nearbyEnemies)
        {
            if (!potentialTarget) continue;
            Vector3 directionToTarget = potentialTarget.position - currentPos;
            float distSqrToTarget = directionToTarget.sqrMagnitude;
            if (distSqrToTarget < closestDistSqr)
            {
                closestDistSqr = distSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }

    public override void Compute(int level)
    {
        switch(level)
        {
            case 2:
                baseDamage += 10;
                break;
            case 3:
                baseDamage += 10;
                baseSpeed *= 1.2f;
                break;
            case 4:
                baseDamage += 10;
                break;
            case 5:
                baseDamage += 10;
                baseSpeed *= 1.2f;
                break;
        }
    }
}
