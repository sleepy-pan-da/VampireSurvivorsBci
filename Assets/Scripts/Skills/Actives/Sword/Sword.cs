using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : ActiveSpecifications
{
    [SerializeField]
    private SwordInstance sword;
    private TopdownMovement playerTopdownMovement;
    private int baseDamage = 5;
    private float cooldown = 1f;
    private float knockbackStrength = 640f;

    private void Start()
    {
        playerTopdownMovement = transform.parent.GetComponent<ActiveSkillsManager>().playerTopdownMovement;
        StartCoroutine(SpawnAfterSeconds(cooldown));
    }

    protected override void Spawn()
    { 
        Quaternion swordRotation = sword.transform.rotation;
        bool isFacingLeft = playerTopdownMovement.isFacingLeft();
        if (isFacingLeft) swordRotation.eulerAngles *= -1;
        SwordInstance swordInstance = Instantiate(sword, transform.position, swordRotation, transform);
        int damage = PlayerStatsManager.Stats.ComputeDamageFromMultiplier(baseDamage);
        swordInstance.swing(damage, isFacingLeft, knockbackStrength);
    }

    public override void Compute(int level)
    {
        switch(level)
        {
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }
}
