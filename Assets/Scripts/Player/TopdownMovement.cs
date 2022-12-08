using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TopdownMovement : MonoBehaviour
{
    [SerializeField]
    private float origMaxMoveSpeed;
    [SerializeField]
    private float origAcceleration;
    private float maxMoveSpeed;
    private float acceleration;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    

    private void Start()
    {
        SetMovementBasedOnStats();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        int movingRight = Convert.ToInt32(Input.GetKey(KeyCode.D));
        int movingLeft = Convert.ToInt32(Input.GetKey(KeyCode.A));
        int movingUp = Convert.ToInt32(Input.GetKey(KeyCode.W));
        int movingDown = Convert.ToInt32(Input.GetKey(KeyCode.S));
        Vector3 direction = new Vector3(movingRight - movingLeft, movingUp - movingDown, 0).normalized;
        
        // Update sprite based on direction
        animator.SetBool("Moving", direction != Vector3.zero);
        if (direction != Vector3.zero)
        {
            spriteRenderer.flipX = direction.x < 0;
        }

        velocity = Vector3.MoveTowards(velocity, maxMoveSpeed * direction, acceleration * Time.deltaTime);
        rb.velocity = velocity;
    }

    public void SetMovementBasedOnStats()
    {
        float movementMultiplier = PlayerStatsManager.Stats.MovementSpeedMultiplier;
        maxMoveSpeed = origMaxMoveSpeed * movementMultiplier;
        acceleration = origAcceleration * movementMultiplier;
    } 
}
