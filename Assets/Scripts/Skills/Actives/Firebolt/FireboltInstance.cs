using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FireboltInstance : MonoBehaviour
{
    public static event Action<string> OnFireFireboltSfx;
    private Rigidbody2D rb;
    private int damage;
    private float knockbackStrength;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void fire(Vector3 direction, int damage, float speed, float knockbackStrength)
    {
        OnFireFireboltSfx?.Invoke("Firebolt");
        Vector2 velocity = direction * speed;
        transform.Rotate(0f, 0f, Vector3.SignedAngle(Vector3.right, direction, Vector3.forward));
        rb.velocity = velocity;
        this.damage = damage;
        this.knockbackStrength = knockbackStrength;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Level")
        {
            Destroy(gameObject);
            return;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject enemy = collision.gameObject;
            KnockbackManager knockbackManager = enemy.GetComponent<KnockbackManager>();
            knockbackManager.ApplyKnockback(gameObject, knockbackStrength);
            EnemyStatsManager enemyStatsManager = enemy.GetComponent<EnemyStatsManager>();
            enemyStatsManager.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void FinishedAnimation()
    {
        Destroy(gameObject);
    }
}
