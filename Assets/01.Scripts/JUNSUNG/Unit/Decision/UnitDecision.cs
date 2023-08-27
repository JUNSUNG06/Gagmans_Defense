using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitDecision : MonoBehaviour
{
    [SerializeField]
    protected bool reverse;
    protected bool result;

    protected UnitController controller;

    public virtual void Init(UnitController _controller)
    {
        controller = _controller;
    }
    public abstract bool Decision();
    public virtual void UpdateDecision() { }
}