using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaver : ActiveSpecifications
{
    [SerializeField]
    private CleaverInstance cleaver;
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
        bool isFacingRight = playerTopdownMovement.isFacingRight();
        Vector3 spawnOffset = cleaver.transform.position;
        StartCoroutine(SpawnCleaver(spawnOffset, isFacingRight));
    }

    private IEnumerator SpawnCleaver(Vector3 spawnOffset, bool isFacingRight)
    {
        for (int i = 0; i < projectileCount; i++)
        {
            CleaverInstance cleaverInstance = Instantiate(cleaver, transform.position + spawnOffset, transform.rotation, transform);
            int damage = PlayerStatsManager.Stats.ComputeDamageFromMultiplier(baseDamage);
            cleaverInstance.fire(damage, baseSpeed, knockbackStrength, skillInstances, isFacingRight, cooldown * 0.3f);
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
