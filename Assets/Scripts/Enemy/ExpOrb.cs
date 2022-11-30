using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExpOrb : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool hasTarget;
    private Transform targetTransform;
    [SerializeField]
    private float moveSpeed = 10f;

    public static event Action<int> OnCollectedExpOrb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Collect()
    {
        OnCollectedExpOrb?.Invoke(1);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (hasTarget)
        {
            Vector2 targetDirection = (targetTransform.position - transform.position).normalized;
            rb.velocity = new Vector2(targetDirection.x, targetDirection.y) * moveSpeed;  
        }
    }

    public void SetTarget(Transform transform)
    {
        targetTransform = transform;
        hasTarget = true;
    }
}
