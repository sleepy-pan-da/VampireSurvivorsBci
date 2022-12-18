using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaverChild : MonoBehaviour
{
    private CleaverInstance cleaverInstance;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    private CapsuleCollider2D capsuleCollider;
    private Vector3 rotationAxis;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        capsuleCollider.enabled = false;
    }

    private void Start()
    {
        cleaverInstance = transform.parent.GetComponent<CleaverInstance>();
    }

    private void Update()
    {
        if (rotationAxis != null) transform.Rotate(rotationAxis, 360f * Time.deltaTime);
    }

    public void setCanRotate(Vector3 rotationAxis)
    {
        this.rotationAxis = rotationAxis;
    }

    public void enableCapsuleCollider(bool enabled)
    {
        capsuleCollider.enabled = enabled;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Level")
        {
            Destroy(cleaverInstance.gameObject);
            return;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject enemy = collision.gameObject;
            KnockbackManager knockbackManager = enemy.GetComponent<KnockbackManager>();
            knockbackManager.ApplyKnockback(gameObject, cleaverInstance.knockbackStrength);
            EnemyStatsManager enemyStatsManager = enemy.GetComponent<EnemyStatsManager>();
            enemyStatsManager.TakeDamage(cleaverInstance.damage);
            Destroy(cleaverInstance.gameObject);
        }
    }
}
