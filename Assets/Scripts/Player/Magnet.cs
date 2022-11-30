using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ExpOrb")
        {
            collision.gameObject.GetComponent<ExpOrb>().SetTarget(transform.parent);
        }
    }
}
