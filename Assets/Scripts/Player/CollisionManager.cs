using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collsion)
    {
        Debug.Log("I collided into something?");
    }
}
