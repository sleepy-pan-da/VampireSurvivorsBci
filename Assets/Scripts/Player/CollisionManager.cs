using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionManager : MonoBehaviour
{
    private HashSet<Collision2D> enemiesTouching = new HashSet<Collision2D>(); 
    public event Action<int> OnTakenDamageFromEnemy;
    public static event Action<string> OnTakingDamageSfx;
    public static event Action<string> OnStopTakingDamage;

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            OnTakenDamageFromEnemy?.Invoke(collision.gameObject.GetComponent<EnemyStatsManager>().Stats.Damage);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemiesTouching.Add(collision);  
            OnTakingDamageSfx?.Invoke("TakingDamage");
        } 
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") enemiesTouching.Remove(collision);
        if (enemiesTouching.Count == 0) OnStopTakingDamage?.Invoke("TakingDamage");
    }
}
