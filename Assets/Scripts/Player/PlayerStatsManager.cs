using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using TMPro;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerStatsManager : MonoBehaviour
{
    public static event Action OnDeath;
    
    [SerializeField]
    private PlayerStats statsToInsert;
    public static PlayerStats Stats;
    [SerializeField]
    private PlayerStats statsDebug;

    private Slider healthBarSlider;
    [SerializeField]
    private ExpBar expBarSlider;
    private TopdownMovement topdownMovement;
    private Magnet magnet;
    private Aura aura; 
    private CollisionManager collisionManager;
    private TextMeshProUGUI concentrationText;

    private void Start()
    {
        Stats = Instantiate(statsToInsert);
        statsDebug = Stats;
        
        // Initialising hp bar
        healthBarSlider = transform.Find("Canvas/HealthBar").GetComponent<Slider>();
        UpdateHealthBarMaxValue();
        UpdateHealthBar(healthBarSlider.maxValue);

        // Initialising exp bar
        if (expBarSlider) expBarSlider.Initialise(Stats);

        topdownMovement = GetComponent<TopdownMovement>();

        magnet = transform.Find("MagnetCollider").GetComponent<Magnet>();
        magnet.setCircleColliderRadius();

        aura = transform.Find("Aura").GetComponent<Aura>();
        concentrationText = transform.Find("Canvas/ConcentrationText").GetComponent<TextMeshProUGUI>();

        collisionManager = GetComponent<CollisionManager>();
        
        // Subscribed classes
        collisionManager.OnTakenDamageFromEnemy += TakeDamage;
        ExpOrb.OnCollectedExpOrb += GainExp;
        PlayerStats.OnChangedMaxHp += UpdateHealthBarMaxValue;
        PlayerStats.OnChangedMovementSpeedMultiplier += topdownMovement.SetMovementBasedOnStats;
        PlayerStats.OnChangedPickupRadiusMultiplier += magnet.setCircleColliderRadius;
        LSLInput.OnHookedUpBci += ShowAura;
        LSLInput.OnPullEEGData += UpdatePlayerConcentration;

        StartCoroutine(RegenHp());
    }

    private void OnDisable()
    {
        collisionManager.OnTakenDamageFromEnemy -= TakeDamage;
        ExpOrb.OnCollectedExpOrb -= GainExp;
        PlayerStats.OnChangedMaxHp -= UpdateHealthBarMaxValue;
        PlayerStats.OnChangedMovementSpeedMultiplier -= topdownMovement.SetMovementBasedOnStats;
        PlayerStats.OnChangedPickupRadiusMultiplier -= magnet.setCircleColliderRadius;
        LSLInput.OnHookedUpBci -= ShowAura;
        LSLInput.OnPullEEGData -= UpdatePlayerConcentration;
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
        expBarSlider.UpdateExp(Stats.CurrentExp);
        if (Stats.CurrentExp == Stats.ExpNeededToLevel)
        {
            Stats.LevelUp();
            // InitialiseExpBar();
            expBarSlider.Initialise(Stats);
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

    // private void InitialiseExpBar()
    // {
    //     expBarSlider.maxValue = Stats.ExpNeededToLevel;
    //     UpdateExpBar(0);
    // }

    // private void UpdateExpBar(int newValue)
    // {
    //     expBarSlider.value = newValue;
    // }

    private void UpdatePlayerConcentration(ExtractedDataFromRawEeg newEEGData)
    {
        if (newEEGData == null) return;
        Stats.SetConcentrationRatio(newEEGData.ConcentrationRatio);
        concentrationText.text = Stats.ConcentrationRatio.ToString();
        aura.UpdateAura(Stats.ConcentrationRatio);
    }

    private void ShowAura()
    {
        Debug.Log("show aura");
        Debug.Log(aura);
        aura.gameObject.SetActive(true);
    }
}
