using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PubBuilding : BaseBuilding
{
    private int currentLevel;
    private int maxLevel;
    [SerializeField] private List<PubSlot> pubSlots;
    [SerializeField] private Transform unitMakeTrm; // ���� �� ��ġ
    [SerializeField] private Transform unitbeginningTrm; // ������ �� ó������ �ɾ ��ġ

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
