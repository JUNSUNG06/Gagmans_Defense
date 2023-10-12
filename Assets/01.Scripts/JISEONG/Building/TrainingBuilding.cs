using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrainingBuilding : BaseBuilding
{
    [SerializeField] private Transform unitMakeTrm; // 훈련소 문 위치
    [SerializeField] private Transform unitbeginningTrm; // 훈련한 후 처음으로 걸어갈 위치

    private TrainingUI ui;
    [SerializeField]
    private float spawnTime = 3f;
    private float currentTime = 0f;
    private Queue<UnitSO> queue;

    public Action<UnitSO> OnBuyEvent;

    public int waitingCount => queue.Count;
    public bool IsWork => queue.Count > 0;

    [SerializeField]
    private List<UnitSO> slotInfo = new List<UnitSO>();
    private void Start()
    {
        queue = new Queue<UnitSO>();
        currentLevel = buildingDataSO.minBuildingLevel;
        Upgrade();

        ui = UIManager.Instance.GetUI<TrainingUI>();

        OnBuyEvent += RegistrationUnit;

        for (int i = 0; i < ui.slotCount; i++)
        {
            ui.slots[i].SetSlot(i, OnBuyEvent, slotInfo[i]);
        }
    }

    private void Update()
    {
        if (waitingCount > 0)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= spawnTime)
            {
                UnitSO unit = queue.Dequeue();
                ui.RemoveWaitSlot();
                UnitManager.Instance.SpawnUnit(unit.unitType, unit.unitName, unitMakeTrm.position);
                currentTime = 0f;
            }

            ui.SetProgress(currentTime / spawnTime * 100);
        }
    }

    public void RegistrationUnit(UnitSO unit) // 유닛 등록
    {
        if (PlayerWallet.Instance.Money < unit.unitCost)
            return;

        PlayerWallet.Instance.Money -= unit.unitCost;
        queue.Enqueue(unit);
        ui.CreateWaitSlot(unit.profile);
    }

    public override void Upgrade()
    {
        currentLevel++;
        if(currentLevel >= maxLevel)
        {
            //건물을 더 이상 강화할 수 없다면 버튼 비활성화 해야함
        }
        UpgradeEvent?.Invoke();
    }

    public override void StopWorking()
    {
        StopAllCoroutines();
    }

    public override void OnClicked()
    {
        ui.Show();
    }
}
