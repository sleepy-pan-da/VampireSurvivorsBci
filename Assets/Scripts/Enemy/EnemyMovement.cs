using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform playerTransform;
    private int speed;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform; 
        speed = GetComponent<EnemyStatsManager>().stats.MovementSpeed;
    }

    // Update is called once per frame
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
