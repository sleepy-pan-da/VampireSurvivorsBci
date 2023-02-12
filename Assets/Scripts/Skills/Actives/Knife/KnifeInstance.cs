using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KnifeInstance : MonoBehaviour
{
    public static event Action<string> OnFireKnifeSfx;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private int damage;
    private float knockbackStrength;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void fire(int damage, float speed, bool isFacingLeft, float knockbackStrength)
    {
        OnFireKnifeSfx?.Invoke("Knife");
        Vector2 velocity = new Vector2(speed, 0); 
        if (isFacingLeft)
        {
            velocity.x *= -1;
            spriteRenderer.flipY = true;  
        } 
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
}
