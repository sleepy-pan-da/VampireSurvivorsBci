using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActiveSkills.Intimidation
{
    public class Manager : MonoBehaviour
    {
        private CircleCollider2D circleCollider2D;
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            circleCollider2D = GetComponent<CircleCollider2D>();
            spriteRenderer = transform.Find("Circle").GetComponent<SpriteRenderer>();
        }

        public void SetCircleRadius(float newRadius)
        {
            circleCollider2D.radius = newRadius;
            float newScale = newRadius * 2;
            spriteRenderer.transform.localScale = new Vector3(newScale, newScale, newScale);
        }
    }
}

