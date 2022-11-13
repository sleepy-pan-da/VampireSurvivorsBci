using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/Stats")]
public class PlayerStats : ScriptableObject
{
    [Header("Done")]
    public int hp;
    public float movementMultiplier = 1F;
    public int level = 1;
    [Header("Wip")]
    public float hpRegen;
    public float lifeStealMultiplier;
    public int currentExp;
    public int expNeededToLevel;
    public float pickupRadius;
    public float damageMultiplier;
    public float cooldownReduction;
}
