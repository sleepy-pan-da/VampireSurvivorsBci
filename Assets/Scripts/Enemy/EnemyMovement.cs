using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(KnockbackManager))]
public class EnemyMovement : MonoBehaviour
{
    private Transform playerTransform;
    private int speed;
    private Rigidbody2D rb;
    private KnockbackManager knockbackManager;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player")?.transform; 
        speed = GetComponent<EnemyStatsManager>().Stats.MovementSpeed;

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
        knockbackManager = GetComponent<KnockbackManager>();

        knockbackManager.OnBegin += Disable;
        knockbackManager.OnDone += Enable;

        ScreenManager.OnReset += Reset;
    }

    private void Reset()
    {
        Debug.Log("Enemy movement resetted");
        knockbackManager.OnBegin -= Disable;
        knockbackManager.OnDone -= Enable;
        ScreenManager.OnReset -= Reset;
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    private void Disable()
    {
        enabled = false;
    }

    private void Enable()
    {
        enabled = true;
    }

    private void FollowPlayer()
    {
        if (playerTransform == null) 
        {
            animator.SetBool("PlayerIsDead", true);
            return;
        }
        float step = speed * Time.deltaTime;
        Vector2 desiredPosition = Vector2.MoveTowards(transform.position, playerTransform.position, step);
        rb.MovePosition(desiredPosition);

        Vector2 directionTowardsPlayer = (playerTransform.position - transform.position).normalized;
        spriteRenderer.flipX = directionTowardsPlayer.x < 0;
    }
}
