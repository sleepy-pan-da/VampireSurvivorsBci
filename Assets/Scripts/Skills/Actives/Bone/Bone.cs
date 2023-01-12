using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : ActiveSpecifications
{
    [SerializeField]
    private BoneInstance bone;
    private float spawnOffset = 0.5f;
    private int baseDamage = 20;
    private float cooldown = 1f;
    private float projectileInterval = 0.1f;
    private int projectileCount = 1;
    private float baseSpeed = 14f;
    private float knockbackStrength = 160f;
    private int pierce;
    private int bounceRemaining = 3;

    private void Start()
    {
        StartCoroutine(SpawnAfterSeconds(cooldown));
    }

    protected override void Spawn()
    {
        StartCoroutine(SpawnBone());
    }   

    private IEnumerator SpawnBone()
    {
        for (int i = 0; i < projectileCount; i++)
        {
            Vector3 direction = GetRandomDirection();
            BoneInstance boneInstance = Instantiate(bone, transform.position + direction * spawnOffset, bone.transform.rotation, skillInstances);
            int damage = PlayerStatsManager.Stats.ComputeDamageFromMultiplier(baseDamage);
            boneInstance.fire(direction, damage, baseSpeed, knockbackStrength, bounceRemaining);
            yield return new WaitForSeconds(projectileInterval);
        }
    }

    private Vector3 GetRandomDirection()
    {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
    }

    public override void Compute(int level)
    {
        switch(level)
        {
            case 2:
                projectileCount = 2;
                break;
            case 3:
                bounceRemaining = 4;
                break;
            case 4:
                projectileCount = 3;
                break;
            case 5:
                bounceRemaining = 5;
                projectileCount = 4;
                baseSpeed = 28f;
                break;
        }
    }
}
