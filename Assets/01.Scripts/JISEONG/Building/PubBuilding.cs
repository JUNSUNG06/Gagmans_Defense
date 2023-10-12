using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PubBuilding : BaseBuilding, IClickable
{
    [SerializeField] private Transform unitMakeTrm; // 주점 문 위치
    [SerializeField] private Transform unitbeginningTrm; // 생성한 후 처음으로 걸어갈 위치

    [SerializeField] List<PubSlotSO> slotInfos;
    private List<PubSlot> pubSlots = new List<PubSlot>();
    private void Start()
    {
        Upgrade();
        Upgrade();
        Upgrade();
    }

    public override void StopWorking()
    {
        
    }

    public override void Upgrade()
    {
        PubSlot pub = new PubSlot(UIManager.Instance.GetUI<PubUI>().slotList[currentLevel], slotInfos[currentLevel].unitSOs, slotInfos[currentLevel].drawTime, unitMakeTrm, unitbeginningTrm);
        pubSlots.Add(pub);
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
}
