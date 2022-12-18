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
    private Vector3 latestDirectionFaced = Vector3.right; // for skills that require player's direction
    
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
        int movingRight = Convert.ToInt32(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow));
        int movingLeft = Convert.ToInt32(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow));
        int movingUp = Convert.ToInt32(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) );
        int movingDown = Convert.ToInt32(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow));
        Vector3 direction = new Vector3(movingRight - movingLeft, movingUp - movingDown, 0).normalized;
        
        // Update sprite based on direction
        animator.SetBool("Moving", direction != Vector3.zero);
        if (direction != Vector3.zero)
        {
            spriteRenderer.flipX = direction.x < 0;
            latestDirectionFaced = direction;
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

    public bool isFacingRight()
    {
        return latestDirectionFaced.x > 0;
    }

    public bool isFacingLeft()
    {
        return latestDirectionFaced.x < 0;
    }


    public Vector3 GetLatestDirectionFaced()
    {
        return latestDirectionFaced;
    }
}
