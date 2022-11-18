using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerStatsManager : MonoBehaviour
{
    public PlayerStats stats;
    private Slider healthBarSlider;

    void Start()
    {
        stats = Instantiate(stats);
        // Initialising hp bar
        healthBarSlider = transform.Find("Canvas/HealthBar").GetComponent<Slider>();
        healthBarSlider.maxValue = (float)stats.MaxHp;
        UpdateHealthBar(healthBarSlider.maxValue);

        // Subscribing to collisionManager
        CollisionManager collisionManager = GetComponent<CollisionManager>();
        collisionManager.OnTakenDamageFromEnemy += TakeDamage;
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
        stats.CurrentHp = Mathf.Max(0, stats.CurrentHp - damage);
        UpdateHealthBar(stats.CurrentHp);
        if (stats.CurrentHp == 0)
        {
            Destroy(gameObject);
        }
    }

    void GainHp(int hpGained)
    {
        stats.CurrentHp = Mathf.Min(stats.CurrentHp + hpGained, stats.MaxHp);
        UpdateHealthBar(stats.CurrentHp);
    }

    void UpdateHealthBar(float newValue)
    {
        healthBarSlider.value = newValue;
    }
}
