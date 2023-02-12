using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sword : ActiveSpecifications
{
    public static event Action<string> OnSwingSwordSfx;
    [SerializeField]
    private SwordInstance sword;
    private TopdownMovement playerTopdownMovement;
    private int baseDamage = 18;
    private float cooldown = 1f;
    private float knockbackStrength = 640f;

    private void Start()
    {
        playerTopdownMovement = transform.parent.GetComponent<ActiveSkillsManager>().playerTopdownMovement;
        StartCoroutine(SpawnAfterSeconds(cooldown));
    }

    protected override void Spawn()
    { 
        OnSwingSwordSfx?.Invoke("Sword");
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
                baseDamage += 2;
                break;
            case 3:
                baseDamage += 2;
                break;
            case 4:
                baseDamage += 2;
                cooldown = 0.9f;
                break;
            case 5:
                baseDamage += 2;
                cooldown = 0.8f;
                break;
        }
    }
}
