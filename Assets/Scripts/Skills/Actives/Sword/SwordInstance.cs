using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordInstance : MonoBehaviour
{
    [HideInInspector]
    public int damage;
    [HideInInspector]
    public float knockbackStrength;
    private SpriteRenderer spriteRenderer;
    private float degreesToRotate = 213f;

    private void Awake()
    {
        Transform childTransform = transform.Find("Child"); 
        spriteRenderer = childTransform.GetComponent<SpriteRenderer>();
    }

    public void swing(int damage, bool isFacingLeft, float knockbackStrength)
    {
        if (isFacingLeft)
        {
            spriteRenderer.flipX = true;  
        } 
        this.damage = damage;
        this.knockbackStrength = knockbackStrength;
        var seq = LeanTween.sequence();

        Vector3 rotationAxis = isFacingLeft ? Vector3.forward : Vector3.back;

        seq.append(LeanTween.rotateAroundLocal(gameObject, rotationAxis, degreesToRotate, 0.5f));
        seq.append(() => {
            Destroy(gameObject);
        });
    }
}
