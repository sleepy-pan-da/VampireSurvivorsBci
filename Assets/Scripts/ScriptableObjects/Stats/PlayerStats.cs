using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/Stats")]
public class PlayerStats : ScriptableObject
{
    [Header("Done")]
    public int MaxHp;
    public int CurrentHp;
    public float MovementSpeedMultiplier = 1f;
    public int Level = 1;
    public int CurrentExp;
    public int ExpNeededToLevel;
    public float DamageMultiplier;
    public int HpRegen;
    public float PickupRadiusMultiplier;
    public float CooldownReduction = 1f;

    [Header("Wip")]
    public float LifeStealMultiplier;

    public static event Action OnChangedMaxHp;
    public static event Action OnChangedMovementSpeedMultiplier;
    public static event Action OnChangedPickupRadiusMultiplier;
    public static event Action OnLeveledUp;

    public void GainHp(int hpGained)
    {
        CurrentHp += hpGained;
        CurrentHp = Mathf.Min(CurrentHp, MaxHp);
    }

    public void SetMaxHp(int newMaxHp)
    {
        MaxHp = newMaxHp;
        OnChangedMaxHp?.Invoke();
    }

    public void SetDamageMultiplier(float newDamageMultiplier)
    {
        DamageMultiplier = newDamageMultiplier;
    }

    public void SetMovementSpeedMultiplier(float newMovementSpeedMultiplier)
    {
        MovementSpeedMultiplier = newMovementSpeedMultiplier;
        OnChangedMovementSpeedMultiplier?.Invoke();
    }

    public void SetHpRegen(int newHpRegen)
    {
        HpRegen = newHpRegen;
    }

    public void SetPickupRadiusMultiplier(float newPickupRadiusMultiplier)
    {
        PickupRadiusMultiplier = newPickupRadiusMultiplier;
        OnChangedPickupRadiusMultiplier?.Invoke();
    }

    public void SetCooldownReduction(float newCooldownReduction)
    {
        CooldownReduction = newCooldownReduction;
    }

    public void TakeDamage(int damage)
    {
        CurrentHp = Mathf.Max(0, CurrentHp - damage);
    }

    public void GainExp(int expGained)
    {
        CurrentExp += expGained;
        CurrentExp = Mathf.Min(CurrentExp, ExpNeededToLevel);
    }

    public void LevelUp()
    {
        Level += 1;
        CurrentExp = 0;
        ExpNeededToLevel = (int)(ExpNeededToLevel * 1.2f);
        OnLeveledUp?.Invoke();
    }

    // Helper method for active skills
    public int ComputeDamageFromMultiplier(int baseDamage)
    {
        return Mathf.CeilToInt(baseDamage * DamageMultiplier);
    }

}
