using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Enemy/Stats")]
public class EnemyStats : ScriptableObject
{
    public int MaxHp;
    public int CurrentHp;
    public int Damage;
    public int NumOfOrbsToDrop;
    public int MovementSpeed;
}
