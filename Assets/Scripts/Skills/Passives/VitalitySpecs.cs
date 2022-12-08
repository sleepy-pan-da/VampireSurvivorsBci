using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitalitySpecs : PassiveSpecifications
{
    public override void Compute()
    {
        PlayerStatsManager.Stats.MaxHp = (int)(PlayerStatsManager.Stats.MaxHp * 1.1f);
    }
}
