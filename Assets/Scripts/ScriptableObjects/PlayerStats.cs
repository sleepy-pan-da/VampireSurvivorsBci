using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/Stats")]
public class PlayerStats : ScriptableObject
{
    [Header("Done")]
    public int MaxHp;
    public int CurrentHp;
    public float MovementMultiplier = 1F;
    public int Level = 1;
    public int CurrentExp;
    public int ExpNeededToLevel;
    [Header("Wip")]
    public float HpRegen;
    public float LifeStealMultiplier;
    public float PickupRadius;
    public float DamageMultiplier;
    public float CooldownReduction;

    public void GainHp(int hpGained)
    {
        CurrentHp += hpGained;
        CurrentHp = Mathf.Min(CurrentHp, MaxHp);
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
        ExpNeededToLevel = (int)(ExpNeededToLevel * 1.5f);
    }

}
