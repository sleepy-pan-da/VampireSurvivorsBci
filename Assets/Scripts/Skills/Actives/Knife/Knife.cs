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
    private int baseDamage = 45;
    private float cooldown = 1f;
    private float projectileInterval = 0.1f;
    private int projectileCount = 1;
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
        Vector3 offset = spawnOffset; 
        bool isFacingLeft = playerTopdownMovement.isFacingLeft();
        if (isFacingLeft) offset.x *= -1;
        StartCoroutine(SpawnKnife(offset, isFacingLeft));
        
    }

    private IEnumerator SpawnKnife(Vector3 offset, bool isFacingLeft)
    {
        for (int i = 0; i < projectileCount; i++)
        {
            KnifeInstance knifeInstance = Instantiate(knife, transform.position + offset, knife.transform.rotation, skillInstances);
            int damage = PlayerStatsManager.Stats.ComputeDamageFromMultiplier(baseDamage);
            knifeInstance.fire(damage, baseSpeed, isFacingLeft, knockbackStrength);
            yield return new WaitForSeconds(projectileInterval);
        }
    }

    public override void Compute(int level)
    {
        switch(level)
        {
            case 2:
                projectileCount = 2;
                break;
            case 3:
                projectileCount = 3;
                break;
            case 4:
                projectileCount = 4;
                break;
            case 5:
                projectileCount = 8;
                break;
        }
    }
}
