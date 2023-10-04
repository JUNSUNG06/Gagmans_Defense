using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PubBuilding : BaseBuilding
{
    private int currentLevel;
    private int maxLevel;
    [SerializeField] private List<PubSlot> pubSlots;
    [SerializeField] private Transform unitMakeTrm; // 주점 문 위치
    [SerializeField] private Transform unitbeginningTrm; // 생성한 후 처음으로 걸어갈 위치

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
        pubSlots[--currentLevel].ActivatePubSlot(currentLevel, unitMakeTrm.position, unitbeginningTrm.position);
        UpgradeEvent?.Invoke();
    }

    public override void OnClicked()
    {
        UIManager.Instance.GetUI<PubUI>().Show();
    }
}
