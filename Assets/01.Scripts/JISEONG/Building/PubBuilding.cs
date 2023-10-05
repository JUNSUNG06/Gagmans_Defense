using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PubBuilding : BaseBuilding
{
    private int currentLevel;
    private int maxLevel;
    [SerializeField] private Transform unitMakeTrm; // 주점 문 위치
    [SerializeField] private Transform unitbeginningTrm; // 생성한 후 처음으로 걸어갈 위치

    [SerializeField] List<PubSlotSO> slotInfos;
    private List<PubSlot> pubSlots = new List<PubSlot>();

    private void Start()
    {
        currentLevel = buildingDataSO.minBuildingLevel;
        
    }

    public override void StopWorking()
    {
        
    }

    public override void Upgrade()
    {
        PubSlot pub = new PubSlot();
        pubSlots.Add(pub);
        pub.Start(slotInfos[currentLevel].unitSOs, slotInfos[currentLevel].drawTime);
        currentLevel++;
        UpgradeEvent?.Invoke();
    }

    private void Update()
    {
        foreach(PubSlot p in pubSlots)
        {
            p.Update();
        }
    }
    public override void OnClicked()
    {
        UIManager.Instance.GetUI<PubUI>().Show();
    }
    private void SetSlotUI()
    {
       // UIManager.Instance.GetUI<PubUI>().SettingSlot(slotNumber, currentSlotData.unitCost);
    }
    private void SetSlotTimer()
    {
        //UIManager.Instance.GetUI<PubUI>().SettingTimer(slotNumber, currentTime);
    }
}
