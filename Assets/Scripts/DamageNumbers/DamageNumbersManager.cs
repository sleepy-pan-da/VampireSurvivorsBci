using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumbersManager : MonoBehaviour
{
    [SerializeField]
    private DamageNumber damageNumberPrefab;
    private Transform instanceParent;

    void Start()
    {
        instanceParent = transform.Find("Canvas");
        EnemyStatsManager.OnTakenDamage += SpawnDamageNumber;
    }

    private void SpawnDamageNumber(int damageNumber, Vector3 position)
    {
        DamageNumber instance = Instantiate(damageNumberPrefab, position, damageNumberPrefab.transform.rotation, instanceParent);
        instance.PopUp(damageNumber);
    }
}
