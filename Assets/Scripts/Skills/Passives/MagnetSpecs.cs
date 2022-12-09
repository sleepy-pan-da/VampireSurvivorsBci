using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetSpecs : PassiveSpecifications
{
    public override void Compute()
    {
        float newPickupRadiusMultiplier = PlayerStatsManager.Stats.PickupRadiusMultiplier * 1.2f;
        PlayerStatsManager.Stats.SetPickupRadiusMultiplier(newPickupRadiusMultiplier);
    }
}
