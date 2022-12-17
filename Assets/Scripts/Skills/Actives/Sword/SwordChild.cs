using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordChild : MonoBehaviour
{
    private SwordInstance swordInstance;
    private void Start()
    {
        swordInstance = transform.parent.GetComponent<SwordInstance>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject enemy = collision.gameObject;
            KnockbackManager knockbackManager = enemy.GetComponent<KnockbackManager>();
            knockbackManager.ApplyKnockback(gameObject, swordInstance.knockbackStrength);
            EnemyStatsManager enemyStatsManager = enemy.GetComponent<EnemyStatsManager>();
            enemyStatsManager.TakeDamage(swordInstance.damage);
        }
    }
}
