using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveSpecifications : MonoBehaviour
{
    public abstract void Compute(int level);
    public Transform skillInstances;
}
