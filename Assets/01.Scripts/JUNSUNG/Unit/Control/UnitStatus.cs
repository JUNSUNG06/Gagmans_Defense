using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatus : UnitComponent
{
    private Dictionary<StatusType, int> statusDictionary = new Dictionary<StatusType, int>();

    public Action<StatusType, int> OnStatusChange;

    public override void Init(UnitController _controller)
    {
        base.Init(_controller);
        foreach (Status status in controller.info.status.StatusInfo)
        {
            statusDictionary.Add(status.Type, status.Value);
        }

        #region
        //List<IAffectedStatus> affectedStatuses = new List<IAffectedStatus>();
        //GetComponents<IAffectedStatus>(affectedStatuses);
        //foreach (IAffectedStatus a in affectedStatuses)
        //{
        //    OnStatusChange += a.OnStatusChange;
        //}
        //foreach(StatusType t in Enum.GetValues(typeof(StatusType)))
        //{
        //    OnStatusChange?.Invoke(t, statusDictionary[t]);
        //}
        #endregion
    }

    public int GetStatus(StatusType type)
    {
        return statusDictionary[type];
    }

    public void ChangeStatus(StatusType type, int value)
    {
        statusDictionary[type] += value;
        statusDictionary[type] = Mathf.Max(1, statusDictionary[type]);
        OnStatusChange?.Invoke(type, statusDictionary[type]);
    }

    public void Buff(StatusType type, int percent, float time)
    {
        StartCoroutine(BuffCo(type, percent, time));
    }

    private IEnumerator BuffCo(StatusType type, int percent, float time)
    {
        int originValue = GetStatus(type);
        int changeAmount = originValue * (percent / 100) - originValue;
        statusDictionary[type] += changeAmount;

        yield return new WaitForSeconds(time);

        statusDictionary[type] -= changeAmount;
    }
}
