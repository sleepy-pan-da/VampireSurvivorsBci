using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ActiveSkills.Intimidation;
using System;

public class Intimidation : ActiveSpecifications
{
    private HashSet<EnemyStatsManager> nearbyEnemies = new HashSet<EnemyStatsManager>(); 
    private Manager manager;
    private int baseDamage = 8;
    private float cooldown = 0.5f;

    // TODO: change skill's aoe from playerstat's aoe modifier?

    private void Start()
    {
        manager = GetComponent<Manager>();
        InvokeRepeating("DamageNearbyEnemies", 0f, cooldown);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            nearbyEnemies.Add(collision.gameObject.GetComponent<EnemyStatsManager>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            nearbyEnemies.Remove(collision.gameObject.GetComponent<EnemyStatsManager>());
        }
    }

    private void DamageNearbyEnemies()
    {
        if (nearbyEnemies.Count == 0) return;

        int damage = PlayerStatsManager.Stats.ComputeDamageFromMultiplier(baseDamage);
        // this list is needed as an exception will be thrown if the set's contents are being deleted in the midst of iteration
        List<EnemyStatsManager> toRemoveFromSet = new List<EnemyStatsManager>();
        foreach (EnemyStatsManager enemyStatsManager in nearbyEnemies)
        {
            if (enemyStatsManager.WillDieFromDamage(damage))
            {
                toRemoveFromSet.Add(enemyStatsManager);
                continue;
            }
            enemyStatsManager?.TakeDamage(damage);
        }
        foreach (EnemyStatsManager enemyStatsManager in toRemoveFromSet)
        {
            enemyStatsManager?.TakeDamage(damage);
        }
    }

    public override void Compute(int level)
    {
        switch(level)
        {
            case 2:
                baseDamage = 9;
                manager.SetCircleRadius(3);
                break;
            case 3:
                baseDamage = 10;
                manager.SetCircleRadius(4);
                break;
            case 4:
                baseDamage = 11;
                manager.SetCircleRadius(5);
                break;
            case 5:
                baseDamage = 12;
                manager.SetCircleRadius(6);
                break;
        }
    }
}
