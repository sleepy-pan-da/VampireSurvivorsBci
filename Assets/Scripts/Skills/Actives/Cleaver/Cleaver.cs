using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaver : ActiveSpecifications
{
    [SerializeField]
    private CleaverInstance cleaver;
    private TopdownMovement playerTopdownMovement;
    private int baseDamage = 20;
    private float cooldown = 1f;
    private float projectileInterval = 0.1f;
    private float baseSpeed = 28f;
    private float knockbackStrength = 160f;
    private int pierce;

    private void Start()
    {
        playerTopdownMovement = transform.parent.GetComponent<ActiveSkillsManager>().playerTopdownMovement;
        StartCoroutine(SpawnAfterSeconds(cooldown));
    }

    protected override void Spawn()
    {
        bool isFacingRight = playerTopdownMovement.isFacingRight();
        Vector3 spawnOffset = cleaver.transform.position;

        CleaverInstance cleaverInstance = Instantiate(cleaver, transform.position + spawnOffset, transform.rotation, transform);
        int damage = PlayerStatsManager.Stats.ComputeDamageFromMultiplier(baseDamage);
        
        cleaverInstance.fire(damage, baseSpeed, knockbackStrength, skillInstances, isFacingRight);
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
