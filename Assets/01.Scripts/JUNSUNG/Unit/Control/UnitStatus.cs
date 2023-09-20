using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatus : UnitComponent
{
    public StatusSO StatusInfo;

    private Dictionary<StatusType, int> statusDictionary = new Dictionary<StatusType, int>();

    public Action<StatusType, int> OnStatusChange;

    public override void Init()
    {
        base.Init();
        foreach (Status status in StatusInfo.StatusInfo)
        {
            statusDictionary.Add(status.Type, status.Value);
        }

        List<IAffectedStatus> affectedStatuses = new List<IAffectedStatus>();
        GetComponents<IAffectedStatus>(affectedStatuses);
        foreach (IAffectedStatus a in affectedStatuses)
        {
            OnStatusChange += a.OnStatusChange;
        }
        foreach(StatusType t in Enum.GetValues(typeof(StatusType)))
        {
            OnStatusChange?.Invoke(t, statusDictionary[t]);
        }

        ChangeStatus(StatusType.Health, 2);
    }

    public float GetStatus(StatusType type)
    {
        return statusDictionary[type];
    }

    public void ChangeStatus(StatusType type, int value)
    {
        statusDictionary[type] += value;
        statusDictionary[type] = Mathf.Max(1, statusDictionary[type]);
        OnStatusChange?.Invoke(type, statusDictionary[type]);
    }
}
