using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : ActiveSpecifications
{
    [SerializeField]
    private KnifeInstance knife;
    [SerializeField]
    private Vector3 spawnOffset;
    private TopdownMovement playerTopdownMovement;
    private int baseDamage = 30;
    private float cooldown = 1f;
    private float projectileInterval = 0.1f;
    private float baseSpeed = 28f;
    private float knockbackStrength = 160f;
    private int pierce;
    private bool canSpawn = true;

    private void Start()
    {
        playerTopdownMovement = transform.parent.GetComponent<ActiveSkillsManager>().playerTopdownMovement;
        StartCoroutine(SpawnAfterSeconds(cooldown));
    }

    IEnumerator SpawnAfterSeconds(float seconds)
    {
        while (canSpawn)
        {
            yield return new WaitForSeconds(seconds);
            Spawn();
        }
    }

    private void Spawn()
    { 
        Vector3 offset = spawnOffset; 
        bool isFacingLeft = !playerTopdownMovement.isFacingRight();
        if (isFacingLeft) offset.x *= -1;
        KnifeInstance knifeInstance = Instantiate(knife, transform.position + offset, knife.transform.rotation, skillInstances);
        int damage = PlayerStatsManager.Stats.ComputeDamageFromMultiplier(baseDamage);
        knifeInstance.fire(damage, baseSpeed, isFacingLeft, knockbackStrength);
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
