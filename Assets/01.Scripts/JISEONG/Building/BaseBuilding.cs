using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public abstract class BaseBuilding : MonoBehaviour, IClickable
{
    protected int currentLevel;
    protected int maxLevel;
    [SerializeField] protected BuildingDataSO buildingDataSO;
    [SerializeField] protected UnityEvent UpgradeEvent;
    protected PlayerWallet playerWallet;

    public void Awake()
    {
        playerWallet = FindObjectOfType<PlayerWallet>();
        currentLevel = buildingDataSO.minBuildingLevel;
        maxLevel = buildingDataSO.maxBuildingLevel;
    }
    public abstract void Upgrade();
    public abstract void StopWorking();
    public abstract void OnClicked();
}
