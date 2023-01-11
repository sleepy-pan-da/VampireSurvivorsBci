using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : ActiveSpecifications
{
    [SerializeField]
    private HammerInstance hammer;
    private TopdownMovement playerTopdownMovement;
    private int baseDamage = 3;
    private float cooldown = 2f;
    private float knockbackStrength = 640f;
    private float stunDuration = 1f;

    private void Start()
    {
        playerTopdownMovement = transform.parent.GetComponent<ActiveSkillsManager>().playerTopdownMovement;
        StartCoroutine(SpawnAfterSeconds(cooldown));
    }

    protected override void Spawn()
    { 
        Quaternion hammerRotation = hammer.transform.rotation;
        bool isFacingLeft = playerTopdownMovement.isFacingLeft();
        if (isFacingLeft) hammerRotation.eulerAngles *= -1;
        HammerInstance hammerInstance = Instantiate(hammer, transform.position, hammerRotation, transform);
        int damage = PlayerStatsManager.Stats.ComputeDamageFromMultiplier(baseDamage);
        hammerInstance.swing(damage, isFacingLeft, knockbackStrength, stunDuration);
    }

    public override void Compute(int level)
    {
        switch(level)
        {
            case 2:
                stunDuration *= 1.1f;
                break;
            case 3:
                stunDuration *= 1.1f;
                break;
            case 4:
                stunDuration *= 1.1f;
                cooldown = 1.5f;
                break;
            case 5:
                stunDuration *= 1.1f;
                cooldown = 1f;
                break;
        }
    }
}
