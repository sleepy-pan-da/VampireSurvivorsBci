using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProficiencySpecs : PassiveSpecifications
{
    public override void Compute(int level)
    {
        float newCooldownReduction = PlayerStatsManager.Stats.CooldownReduction * 0.9f;
        PlayerStatsManager.Stats.SetCooldownReduction(newCooldownReduction);
    }
}
