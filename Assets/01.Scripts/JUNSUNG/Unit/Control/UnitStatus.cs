using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatus : MonoBehaviour
{
    private const int MaxStatusValue = 5;

    public StatusSO StatusInfo;

    private Dictionary<StatusType, float> statusDictionary = new Dictionary<StatusType, float>();

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

    public void ChangeStatus(StatusType type, float value)
    {
        statusDictionary[type] = Mathf.Clamp(statusDictionary[type] += value, 0, MaxStatusValue);
    }
}
