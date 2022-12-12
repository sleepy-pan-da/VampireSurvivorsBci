using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsManager : MonoBehaviour
{
    public EnemyStats Stats;
    [SerializeField]
    private GameObject expOrb;

    private void Start()
    {
        Stats = Instantiate(Stats);
    }

    private void Update()
    {
        // Testing purposes
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        Stats.CurrentHp = Mathf.Max(0, Stats.CurrentHp - damage);
        if (Stats.CurrentHp == 0)
        {
            Instantiate(expOrb, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public bool WillDieFromDamage(int damage)
    {
        return (Stats.CurrentHp - damage <= 0);
    }
}
