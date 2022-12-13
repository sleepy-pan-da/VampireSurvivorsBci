using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeInstance : MonoBehaviour
{
    private Rigidbody2D rb;
    private int damage;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void fire(int damage, float speed, bool isFacingLeft)
    {
        Vector2 velocity = new Vector2(speed, 0); 
        if (isFacingLeft) velocity.x *= -1;
        rb.velocity = velocity;
        this.damage = damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Level")
        {
            Destroy(gameObject);
            return;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyStatsManager enemyStatsManager = collision.gameObject.GetComponent<EnemyStatsManager>();
            enemyStatsManager.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
