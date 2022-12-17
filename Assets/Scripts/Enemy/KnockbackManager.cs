using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class KnockbackManager : MonoBehaviour
{
    private Rigidbody2D rb;
    private float stunDuration = 0.15f;
    public Action OnBegin, OnDone;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // applies knockback from sender to gameobject
    public void ApplyKnockback(GameObject sender, float knockbackStrength)
    {
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb.AddForce(direction * knockbackStrength, ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }

    public void ApplyKnockback(GameObject sender, float knockbackStrength, float stunDuration)
    {
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb.AddForce(direction * knockbackStrength, ForceMode2D.Impulse);
        this.stunDuration = stunDuration;
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(stunDuration);
        OnDone?.Invoke();
    }
}
