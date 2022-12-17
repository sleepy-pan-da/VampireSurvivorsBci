using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerChild : MonoBehaviour
{
    private HammerInstance hammerInstance;
    private void Start()
    {
        hammerInstance = transform.parent.GetComponent<HammerInstance>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject enemy = collision.gameObject;
            KnockbackManager knockbackManager = enemy.GetComponent<KnockbackManager>();
            knockbackManager.ApplyKnockback(gameObject, hammerInstance.knockbackStrength, hammerInstance.stunDuration);
            EnemyStatsManager enemyStatsManager = enemy.GetComponent<EnemyStatsManager>();
            enemyStatsManager.TakeDamage(hammerInstance.damage);
        }
    }
}
