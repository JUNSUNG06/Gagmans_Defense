using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatus : MonoBehaviour
{
    public StatusSO StatusInfo;

    private Dictionary<StatusType, int> statusDictionary = new Dictionary<StatusType, int>();

    public Action<StatusType, int> OnStatusChange;

    private void Awake()
    {
        foreach (Status status in StatusInfo.StatusInfo)
        {
            statusDictionary.Add(status.Type, status.Value);
        }
    }

    public float GetStatus(StatusType type)
    {
        return statusDictionary[type];
    }

    public void ChangeStatus(StatusType type, int value)
    {
        OnStatusChange?.Invoke(type, value);
    }
}
