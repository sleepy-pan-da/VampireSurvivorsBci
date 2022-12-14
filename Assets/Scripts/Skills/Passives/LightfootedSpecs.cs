using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightfootedSpecs : PassiveSpecifications
{
    public override void Compute(int level)
    {
        float newMovementSpeedMultiplier = PlayerStatsManager.Stats.MovementSpeedMultiplier * 1.1f;
        PlayerStatsManager.Stats.SetMovementSpeedMultiplier(newMovementSpeedMultiplier);
    }
}
