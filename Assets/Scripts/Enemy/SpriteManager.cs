using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteManager : MonoBehaviour
{
    private SpriteRenderer sprite;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void OnTakeDamage()
    {
        StartCoroutine(FlashWhite());
    }

    private IEnumerator FlashWhite()
    {
        sprite.material.SetFloat("_FlashAmount", 1f);
        yield return new WaitForSeconds(0.1f);
        sprite.material.SetFloat("_FlashAmount", 0f);
    }
}
