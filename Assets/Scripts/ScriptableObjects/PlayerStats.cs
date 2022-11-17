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
    [Header("Wip")]
    public float HpRegen;
    public float LifeStealMultiplier;
    public int CurrentExp;
    public int ExpNeededToLevel;
    public float PickupRadius;
    public float DamageMultiplier;
    public float CooldownReduction;
}
