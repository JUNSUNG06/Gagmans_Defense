using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAffectedStatus
{
    public void OnStatusChange(StatusType type, int value);
}