using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public abstract class BaseBuilding : MonoBehaviour
{
    [SerializeField] protected BuildingDataSO buildingDataSO;
    [SerializeField] protected UnityEvent UpgradeEvent;
    public abstract void Upgrade();
    public abstract void StopWorking();
}
