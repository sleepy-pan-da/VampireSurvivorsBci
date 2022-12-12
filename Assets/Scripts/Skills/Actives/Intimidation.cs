using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intimidation : MonoBehaviour
{
    private int baseDamage = 3;
    private HashSet<EnemyStatsManager> nearbyEnemies = new HashSet<EnemyStatsManager>(); 

    // TODO: change skill's aoe from playerstat's aoe modifier?

    private void Start()
    {
        InvokeRepeating("DamageNearbyEnemies", 0f, 0.1f);
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
}
