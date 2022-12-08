using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class PlayerStatsManager : MonoBehaviour
{
    [SerializeField]
    private PlayerStats statsToInsert;
    public static PlayerStats Stats;
    [SerializeField]
    private PlayerStats statsDebug;
    public static event Action OnDeath;

    private Slider healthBarSlider;
    [SerializeField]
    private Slider expBarSlider;

    void Start()
    {
        Stats = Instantiate(statsToInsert);
        statsDebug = Stats;
        
        // Initialising hp bar
        healthBarSlider = transform.Find("Canvas/HealthBar").GetComponent<Slider>();
        healthBarSlider.maxValue = (float)Stats.MaxHp;
        UpdateHealthBar(healthBarSlider.maxValue);

        // Initialising exp bar
        if (expBarSlider)
        {
            InitialiseExpBar();
        }

        // Subscribed classes
        CollisionManager collisionManager = GetComponent<CollisionManager>();
        collisionManager.OnTakenDamageFromEnemy += TakeDamage;

        ExpOrb.OnCollectedExpOrb += GainExp;
    }

    void TakeDamage(int damage)
    {
        Stats.TakeDamage(damage);
        UpdateHealthBar(Stats.CurrentHp);
        if (Stats.CurrentHp == 0)
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }

    void GainHp(int hpGained)
    {
        Stats.GainHp(hpGained);
        UpdateHealthBar(Stats.CurrentHp);
    }

    void GainExp(int expGained)
    {
        Stats.GainExp(expGained);
        UpdateExpBar(Stats.CurrentExp);
        if (Stats.CurrentExp == Stats.ExpNeededToLevel)
        {
            Stats.LevelUp();
            InitialiseExpBar();
        }
    }

    void UpdateHealthBar(float newValue)
    {
        healthBarSlider.value = newValue;
    }
    void InitialiseExpBar()
    {
        expBarSlider.maxValue = Stats.ExpNeededToLevel;
        UpdateExpBar(0);
    }

    void UpdateExpBar(int newValue)
    {
        expBarSlider.value = newValue;
    }

}
