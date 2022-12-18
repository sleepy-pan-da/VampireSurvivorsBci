using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaverInstance : MonoBehaviour
{
    [HideInInspector]
    public int damage;
    [HideInInspector]
    public float knockbackStrength;
    private CleaverChild cleaverChild;
    private float degreesToRotate = 90f;


    private void Awake()
    {
        Transform childTransform = transform.Find("Child");
        cleaverChild = childTransform.GetComponent<CleaverChild>();
    }

    public void fire(int damage, float speed, float knockbackStrength, Transform skillInstances, bool isFacingRight)
    {
        Vector2 velocity = new Vector2(speed, 0);
        if (isFacingRight)
        {
            velocity.x *= -1;
            cleaverChild.spriteRenderer.flipX = true;
        }
        this.damage = damage;
        this.knockbackStrength = knockbackStrength;

        var seq = LeanTween.sequence();
        Vector3 rotationAxis = isFacingRight ? Vector3.back : Vector3.forward;
        seq.append(LeanTween.rotateAroundLocal(gameObject, rotationAxis, degreesToRotate, 0.3f));
        seq.append(LeanTween.rotateAroundLocal(gameObject, rotationAxis, -(degreesToRotate + 45f), 0.1f));

        seq.append(() => {
            transform.parent = skillInstances;
            cleaverChild.rb.velocity = velocity;
            cleaverChild.setCanRotate(rotationAxis * -1);
            cleaverChild.enableCapsuleCollider(true);
        });
    }
}
