using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform playerTransform;
    private int speed;
    
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform; 
        speed = GetComponent<EnemyStatsManager>().Stats.MovementSpeed;
    }


    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (playerTransform == null) return;
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, step);
    }
}
