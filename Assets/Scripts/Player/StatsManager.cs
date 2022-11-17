using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StatsManager : MonoBehaviour
{
    public PlayerStats stats;
    private Slider healthBarSlider;

    // Start is called before the first frame update
    void Start()
    {
        healthBarSlider = transform.Find("Canvas/HealthBar").GetComponent<Slider>();
        Initialise();
    }

    void Initialise()
    {
        healthBarSlider.maxValue = (float)stats.MaxHp;
        UpdateHealthBar(healthBarSlider.maxValue);
    }

    // Update is called once per frame
    void Update()
    {
        // Testing purposes
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TakeDamage(10);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GainHp(10);
        }
    }

    void TakeDamage(int damage)
    {
        stats.CurrentHp = Mathf.Max(0, stats.CurrentHp - damage);
        UpdateHealthBar(stats.CurrentHp);
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
