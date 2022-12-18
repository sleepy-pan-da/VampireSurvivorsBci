using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : ActiveSpecifications
{
    private HashSet<Transform> nearbyEnemies = new HashSet<Transform>(); 
    [SerializeField]
    private SpearInstance spear;
    private int baseDamage = 10;
    private float cooldown = 1f;
    private float projectileInterval = 0.1f;
    private float baseSpeed = 28f;
    private float knockbackStrength = 160f;
    private int pierce;
    
    private void Start()
    {
        StartCoroutine(SpawnAfterSeconds(cooldown));
    }

    protected override void Spawn()
    {
        Transform furthestEnemy = GetFurthestEnemy();
        if (!furthestEnemy) return;

        Vector3 direction = (furthestEnemy.position - transform.position).normalized;
        SpearInstance spearInstance = Instantiate(spear, transform.position + direction, spear.transform.rotation, transform);
        int damage = PlayerStatsManager.Stats.ComputeDamageFromMultiplier(baseDamage);
        
        spearInstance.fire(direction, damage, baseSpeed, knockbackStrength, skillInstances);
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

    private Transform GetFurthestEnemy()
    {
        Transform bestTarget = null;
        float furthestDistSqr = 0f;
        Vector3 currentPos = transform.position;
        foreach (Transform potentialTarget in nearbyEnemies)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPos;
            float distSqrToTarget = directionToTarget.sqrMagnitude;
            if (distSqrToTarget > furthestDistSqr)
            {
                furthestDistSqr = distSqrToTarget;
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
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }
}
