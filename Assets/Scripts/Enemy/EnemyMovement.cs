using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform playerTransform;
    private int speed;
    private Rigidbody2D rb;
    
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player")?.transform; 
        speed = GetComponent<EnemyStatsManager>().Stats.MovementSpeed;

        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (playerTransform == null) return;
        float step = speed * Time.deltaTime;
        Vector2 desiredPosition = Vector2.MoveTowards(transform.position, playerTransform.position, step);
        rb.MovePosition(desiredPosition);
    }
}
