using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/StatusSO")]
public class StatusSO : ScriptableObject
{
    public List<Status> StatusInfo = new List<Status>();

    public int GetStat(StatusType s)
    {
        return StatusInfo.Find(x => x.Type == s).Value;
    }
}
