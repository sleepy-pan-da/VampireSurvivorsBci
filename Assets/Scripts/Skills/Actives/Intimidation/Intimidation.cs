using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ActiveSkills.Intimidation;

public class Intimidation : ActiveSpecifications
{
    private HashSet<EnemyStatsManager> nearbyEnemies = new HashSet<EnemyStatsManager>(); 
    private Manager manager;
    private int baseDamage = 15;
    // TODO: change skill's aoe from playerstat's aoe modifier?

    private void Start()
    {
        manager = GetComponent<Manager>();
        InvokeRepeating("DamageNearbyEnemies", 0f, 0.5f);
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
            enemyStatsManager.TakeDamage(damage);
        }
        foreach (EnemyStatsManager enemyStatsManager in toRemoveFromSet)
        {
            enemyStatsManager.TakeDamage(damage);
        }
    }

    public override void Compute(int level)
    {
        switch(level)
        {
            case 2:
                baseDamage = 10;
                break;
            case 3:
                manager.SetCircleRadius(4);
                break;
            case 4:
                break;
        }
    }
}
