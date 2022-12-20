using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitalitySpecs : PassiveSpecifications
{
    public override void Compute(int level)
    {
        int newMaxHp = (int)(PlayerStatsManager.Stats.MaxHp * 1.1f);
        PlayerStatsManager.Stats.SetMaxHp(newMaxHp);
    }
}
