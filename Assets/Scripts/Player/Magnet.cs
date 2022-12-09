using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private CircleCollider2D circleCollider2D;
    private float origRadius;

    private void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        origRadius = circleCollider2D.radius;
    }

    public void setCircleColliderRadius()
    {
        float newRadius = origRadius * PlayerStatsManager.Stats.PickupRadiusMultiplier;
        circleCollider2D.radius = newRadius;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ExpOrb")
        {
            collision.gameObject.GetComponent<ExpOrb>().SetTarget(transform.parent);
        }
    }
}
