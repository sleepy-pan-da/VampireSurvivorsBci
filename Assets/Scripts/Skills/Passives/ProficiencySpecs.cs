using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProficiencySpecs : PassiveSpecifications
{
    public override void Compute(int level)
    {
        float newCooldownReduction = 0.5f;
        PlayerStatsManager.Stats.SetCooldownReduction(newCooldownReduction);
    }
}
