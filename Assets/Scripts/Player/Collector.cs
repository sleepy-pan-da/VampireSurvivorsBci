using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collector : MonoBehaviour
{
    public static event Action<string> OnCollectCoinSfx;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ExpOrb")
        {
            collision.gameObject.GetComponent<ExpOrb>().Collect();
            OnCollectCoinSfx?.Invoke("CollectCoin");
        }
    }
}
