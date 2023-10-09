using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PubBuilding : BaseBuilding
{
    [SerializeField] private Transform unitMakeTrm; // ���� �� ��ġ
    [SerializeField] private Transform unitbeginningTrm; // ������ �� ó������ �ɾ ��ġ

    [SerializeField] List<PubSlotSO> slotInfos;
    private List<PubSlot> pubSlots = new List<PubSlot>();
    private void Start()
    {
        Upgrade();
    }

    public override void StopWorking()
    {
        
    }

    public override void Upgrade()
    {
        PubSlot pub = new PubSlot(UIManager.Instance.GetUI<PubUI>().slotList[currentLevel], slotInfos[currentLevel].unitSOs, slotInfos[currentLevel].drawTime);
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
