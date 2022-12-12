using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeterminationSpecs : PassiveSpecifications
{
    public override void Compute(int level)
    {
        float newDamageMultiplier = PlayerStatsManager.Stats.DamageMultiplier * 1.1f;
        PlayerStatsManager.Stats.SetDamageMultiplier(newDamageMultiplier);
    }
}
