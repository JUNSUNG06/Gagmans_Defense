using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitState : MonoBehaviour
{
    protected UnitController controller;
    protected UnitMovement movement;

    public virtual void InitState(Transform rootTrm)
    {
        controller = rootTrm.GetComponentInParent<UnitController>();
        movement = rootTrm.GetComponent<UnitMovement>();
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
}
