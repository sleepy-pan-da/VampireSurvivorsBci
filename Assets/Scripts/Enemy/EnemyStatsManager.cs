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
    private SpriteManager spriteManager;
    public static event Action<int, Vector3> OnTakenDamage;

    private void Start()
    {
        Stats = Instantiate(Stats);
        spriteManager = GetComponent<SpriteManager>();
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
        spriteManager.OnTakeDamage();
        OnTakenDamage?.Invoke(damage, transform.position);

        // var seq = LeanTween.sequence();
        
        // seq.append(LeanTween.scale(gameObject, new Vector3(1.2f, 1.2f), 0.1f).setEase(LeanTweenType.easeInOutCubic));
        // seq.append(LeanTween.scale(gameObject, new Vector3(1f, 1f), 0.2f).setEase(LeanTweenType.easeInOutCubic));
        
        if (Stats.CurrentHp == 0)
        {
            Instantiate(expOrb, transform.position, transform.rotation, Pickups);
            Destroy(gameObject);
        }
    }

    public bool WillDieFromDamage(int damage)
    {
        return (Stats.CurrentHp - damage <= 0);
    }
}
