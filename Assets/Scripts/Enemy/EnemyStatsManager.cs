using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyStatsManager : MonoBehaviour
{
    public EnemyStats Stats;
    [HideInInspector]
    public Transform Pickups;
    [SerializeField]
    private GameObject expOrb;
    private SimpleFlash simpleFlash;
    public static event Action<int, Vector3> OnTakenDamage;
    public static event Action<string> OnTakenDamageSfx;
    private bool toBeDestroyed = false;

    private void Start()
    {
        Stats = Instantiate(Stats);
        simpleFlash = GetComponent<SimpleFlash>();
    }

    private void Update()
    {
        // Testing purposes
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        if (toBeDestroyed) return;
        OnTakenDamageSfx?.Invoke("EnemyHit");
        if (!WillDieFromDamage(damage)) simpleFlash.Flash();
        Stats.CurrentHp = Mathf.Max(0, Stats.CurrentHp - damage);
        if (transform != null) OnTakenDamage?.Invoke(damage, transform.position);
        if (Stats.CurrentHp == 0)
        {
            Instantiate(expOrb, transform.position, transform.rotation, Pickups);
            toBeDestroyed = true;
            Destroy(gameObject);
        }
    }

    public bool WillDieFromDamage(int damage)
    {
        return (Stats.CurrentHp - damage <= 0);
    }
}
