using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsManager : MonoBehaviour
{
    public EnemyStats Stats;
    [SerializeField]
    private GameObject expOrb;

    void Start()
    {
        Stats = Instantiate(Stats);
    }

    void Update()
    {
        // Testing purposes
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
    {
        Stats.CurrentHp = Mathf.Max(0, Stats.CurrentHp - damage);
        if (Stats.CurrentHp == 0)
        {
            Instantiate(expOrb, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
