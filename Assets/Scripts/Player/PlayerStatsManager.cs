using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerStatsManager : MonoBehaviour
{
    public PlayerStats Stats;
    private Slider healthBarSlider;

    void Start()
    {
        Stats = Instantiate(Stats);
        // Initialising hp bar
        healthBarSlider = transform.Find("Canvas/HealthBar").GetComponent<Slider>();
        healthBarSlider.maxValue = (float)Stats.MaxHp;
        UpdateHealthBar(healthBarSlider.maxValue);

        // Subscribed classes
        CollisionManager collisionManager = GetComponent<CollisionManager>();
        collisionManager.OnTakenDamageFromEnemy += TakeDamage;

        ExpOrb.OnCollectedExpOrb += GainExp;
    }

    void Update()
    {
        // Testing purposes
        // if (Input.GetKeyDown(KeyCode.LeftArrow))
        // {
        //     TakeDamage(10);
        // }
        // else if (Input.GetKeyDown(KeyCode.RightArrow))
        // {
        //     GainHp(10);
        // }
    }

    void TakeDamage(int damage)
    {
        Stats.CurrentHp = Mathf.Max(0, Stats.CurrentHp - damage);
        UpdateHealthBar(Stats.CurrentHp);
        if (Stats.CurrentHp == 0)
        {
            Destroy(gameObject);
        }
    }

    void GainHp(int hpGained)
    {
        Stats.CurrentHp = Mathf.Min(Stats.CurrentHp + hpGained, Stats.MaxHp);
        UpdateHealthBar(Stats.CurrentHp);
    }

    void GainExp(int expGained)
    {
        Stats.CurrentExp = Mathf.Min(Stats.CurrentExp + expGained, Stats.ExpNeededToLevel);
    }

    void UpdateHealthBar(float newValue)
    {
        healthBarSlider.value = newValue;
    }
}
