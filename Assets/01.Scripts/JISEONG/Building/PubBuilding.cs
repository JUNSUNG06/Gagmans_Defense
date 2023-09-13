using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PubBuilding : BaseBuilding
{
    private int currentLevel;
    private int maxLevel;
    [SerializeField] private List<PubSlot> pubSlots;

    private void Start()
    {
        currentLevel = buildingDataSO.minBuildingLevel;
    }

    public override void StopWorking()
    {
        
    }

    public override void Upgrade()
    {
        currentLevel++;
        pubSlots[--currentLevel].ActivatePubSlot();
        UpgradeEvent?.Invoke();
    }
}
