using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerInstance : MonoBehaviour
{
    [HideInInspector]
    public int damage;
    [HideInInspector]
    public float knockbackStrength;
    [HideInInspector]
    public float stunDuration;
    private SpriteRenderer spriteRenderer;
    private float degreesToRotate = 393f;

    private void Awake()
    {
        Transform childTransform = transform.Find("Child"); 
        spriteRenderer = childTransform.GetComponent<SpriteRenderer>();
    }

    public void swing(int damage, bool isFacingLeft, float knockbackStrength, float stunDuration)
    {
        if (isFacingLeft)
        {
            spriteRenderer.flipX = true;  
        } 
        this.damage = damage;
        this.knockbackStrength = knockbackStrength;
        this.stunDuration = stunDuration;
        var seq = LeanTween.sequence();

        Vector3 rotationAxis = isFacingLeft ? Vector3.forward : Vector3.back;

        seq.append(LeanTween.rotateAroundLocal(gameObject, rotationAxis, degreesToRotate, 1f));
        seq.append(() => {
            Destroy(gameObject);
        });
    }
}
