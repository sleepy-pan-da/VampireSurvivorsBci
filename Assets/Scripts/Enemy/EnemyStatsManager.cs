using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsManager : MonoBehaviour
{
    public EnemyStats Stats;
    [SerializeField]
    private GameObject expOrb;
    private SpriteManager spriteManager;

    private void Start()
    {
        Stats = Instantiate(Stats);
        spriteManager = GetComponent<SpriteManager>();
    }

    private void Update()
    {
        // Testing purposes
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        Stats.CurrentHp = Mathf.Max(0, Stats.CurrentHp - damage);
        spriteManager.OnTakeDamage();

        // var seq = LeanTween.sequence();
        
        // seq.append(LeanTween.scale(gameObject, new Vector3(1.2f, 1.2f), 0.1f).setEase(LeanTweenType.easeInOutCubic));
        // seq.append(LeanTween.scale(gameObject, new Vector3(1f, 1f), 0.2f).setEase(LeanTweenType.easeInOutCubic));
        
        if (Stats.CurrentHp == 0)
        {
            Instantiate(expOrb, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public bool WillDieFromDamage(int damage)
    {
        return (Stats.CurrentHp - damage <= 0);
    }
}
