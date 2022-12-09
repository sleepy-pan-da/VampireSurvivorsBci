using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResilienceSpecs : PassiveSpecifications
{
    public override void Compute()
    {
        int newHpRegen = PlayerStatsManager.Stats.HpRegen + 1;
        PlayerStatsManager.Stats.SetHpRegen(newHpRegen);
    }
}
