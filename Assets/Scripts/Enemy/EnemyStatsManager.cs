using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsManager : MonoBehaviour
{
    public EnemyStats stats;
    [SerializeField]
    private GameObject expOrb;

    void Start()
    {
        stats = Instantiate(stats);
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
        stats.CurrentHp = Mathf.Max(0, stats.CurrentHp - damage);
        if (stats.CurrentHp == 0)
        {
            Instantiate(expOrb, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
