using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseActions : MonoBehaviour
{
    protected Unit unit;
    protected bool isActive;

    protected virtual void Awake()
    {
        unit = GetComponent<Unit>();
    }
}
