using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExpOrb : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform targetTransform;
    [SerializeField]
    private float moveSpeed = 10f;

    public static event Action<int> OnCollectedExpOrb; // int -> exp earned

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
        if (targetTransform)
        {
            Vector2 targetDirection = (targetTransform.position - transform.position).normalized;
            rb.velocity = new Vector2(targetDirection.x, targetDirection.y) * moveSpeed;  
        }
    }

    public void SetTarget(Transform transform)
    {
        targetTransform = transform;
    }
}
