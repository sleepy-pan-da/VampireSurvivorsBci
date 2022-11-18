using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionManager : MonoBehaviour
{
    public event Action<int> OnTakenDamageFromEnemy;
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            OnTakenDamageFromEnemy?.Invoke(collision.gameObject.GetComponent<EnemyStatsManager>().stats.Damage);
        }
    }
}
