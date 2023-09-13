using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBuilding : MonoBehaviour, IDamageable
{
    [SerializeField] protected BuildingDataSO buildingDataSO;
    public abstract void GetDamaged(float damage, out bool isKill);

    public abstract void Upgrade();
}
