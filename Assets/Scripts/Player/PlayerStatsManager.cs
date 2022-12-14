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
    private TopdownMovement topdownMovement;
    private Magnet magnet;

    private void Start()
    {
        Stats = Instantiate(statsToInsert);
        statsDebug = Stats;
        
        // Initialising hp bar
        healthBarSlider = transform.Find("Canvas/HealthBar").GetComponent<Slider>();
        UpdateHealthBarMaxValue();
        UpdateHealthBar(healthBarSlider.maxValue);

        // Initialising exp bar
        if (expBarSlider) InitialiseExpBar();

        topdownMovement = GetComponent<TopdownMovement>();

        magnet = transform.Find("MagnetCollider").GetComponent<Magnet>();
        magnet.setCircleColliderRadius();

        // Subscribed classes
        CollisionManager collisionManager = GetComponent<CollisionManager>();
        collisionManager.OnTakenDamageFromEnemy += TakeDamage;

        ExpOrb.OnCollectedExpOrb += GainExp;

        PlayerStats.OnChangedMaxHp += UpdateHealthBarMaxValue;
        PlayerStats.OnChangedMovementSpeedMultiplier += topdownMovement.SetMovementBasedOnStats;
        PlayerStats.OnChangedPickupRadiusMultiplier += magnet.setCircleColliderRadius;

        StartCoroutine(RegenHp());
    }

    private void TakeDamage(int damage)
    {
        Stats.TakeDamage(damage);
        UpdateHealthBar(Stats.CurrentHp);
        if (Stats.CurrentHp == 0)
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }

    private IEnumerator RegenHp()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            GainHp(Stats.HpRegen);
        }
    }

    private void GainHp(int hpGained)
    {
        Stats.GainHp(hpGained);
        UpdateHealthBar(Stats.CurrentHp);
    }

    private void GainExp(int expGained)
    {
        Stats.GainExp(expGained);
        UpdateExpBar(Stats.CurrentExp);
        if (Stats.CurrentExp == Stats.ExpNeededToLevel)
        {
            Stats.LevelUp();
            InitialiseExpBar();
        }
    }

    private void UpdateHealthBar(float newValue)
    {
        healthBarSlider.value = newValue;
    }

    private void UpdateHealthBarMaxValue()
    {
        healthBarSlider.maxValue = (float)Stats.MaxHp;
    }

    private void InitialiseExpBar()
    {
        expBarSlider.maxValue = Stats.ExpNeededToLevel;
        UpdateExpBar(0);
    }

    private void UpdateExpBar(int newValue)
    {
        expBarSlider.value = newValue;
    }

}
