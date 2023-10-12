using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training : MonoBehaviour, IClickable
{
    private TrainingUI ui;
    [SerializeField]
    private float spawnTime = 3f;
    [SerializeField]
    private Transform spawnTrm;
    private float currentTime = 0f;
    private Queue<UnitSO> queue = new Queue<UnitSO>();

    public Action<UnitSO> OnBuyEvent;

    public int waitingCount => queue.Count;

    [SerializeField]
    private List<UnitSO> slotInfo = new List<UnitSO>();

    private void Start()
    {
        ui = UIManager.Instance.GetUI<TrainingUI>();

        OnBuyEvent += AddQueue;

        for (int i = 0; i < ui.slotCount; i++)
        {
            ui.slots[i].SetSlot(i, OnBuyEvent, slotInfo[i]);
        }
    }

    private void Update()
    {
        if(waitingCount > 0)
        {
            currentTime += Time.deltaTime;

            if(currentTime >= spawnTime)
            {
                UnitSO unit = queue.Dequeue();
                ui.RemoveWaitSlot();
                PlayerManager.Instance.SpawnUnit(unit.unitType, unit.unitName, spawnTrm.position);
                currentTime = 0f;
            }

            ui.SetProgress(currentTime / spawnTime * 100);
        }
    }

    public void OnClicked()
    {
        ui.Show();
    }

    private void OnMouseDown()
    {
        ui.Show();
    }

    public void AddQueue(UnitSO unit)
    {
        if (PlayerWallet.Instance.Money < unit.unitCost)
            return;

        PlayerWallet.Instance.Money -= unit.unitCost;
        queue.Enqueue(unit);
        ui.CreateWaitSlot(unit.profile);
    }
}
