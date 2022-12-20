using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoneInstance : MonoBehaviour
{
    private Rigidbody2D rb;
    private int damage;
    private float knockbackStrength;
    private int bounceRemaining;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void fire(Vector3 direction, int damage, float speed, float knockbackStrength, int bounceRemaining)
    {
        Vector2 velocity = direction * speed;
        transform.Rotate(0f, 0f, Vector3.SignedAngle(Vector3.right, direction, Vector3.forward));
        rb.velocity = velocity;
        this.damage = damage;
        this.knockbackStrength = knockbackStrength;
        this.bounceRemaining = bounceRemaining;
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, 360f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Level")
        {
            Bounce(collision);
            return;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject enemy = collision.gameObject;
            KnockbackManager knockbackManager = enemy.GetComponent<KnockbackManager>();
            knockbackManager.ApplyKnockback(gameObject, knockbackStrength);
            EnemyStatsManager enemyStatsManager = enemy.GetComponent<EnemyStatsManager>();
            enemyStatsManager.TakeDamage(damage);
            Bounce(collision);
        }
    }

    private void Bounce(Collider2D collision)
    {
        Vector3 bounceDirection = ComputeBounceDirection(collision);
        rb.velocity = bounceDirection * rb.velocity.magnitude;
        bounceRemaining -= 1;
        if (bounceRemaining == 0) Destroy(gameObject);
    }

    private Vector3 ComputeBounceDirection(Collider2D collision)
    {
        if (collision.gameObject.tag == "Level") return -transform.position.normalized;
        else if (collision.gameObject.tag == "Enemy") return (transform.position - collision.transform.position).normalized;
        return Vector3.zero;
    }
}
