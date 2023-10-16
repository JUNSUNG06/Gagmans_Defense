using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitInfo
{
    public UnitSO unit;
    public int unitCnt;
}

[CreateAssetMenu(menuName = "SO/StageInfoSO")]
public class StageInfoSO : ScriptableObject
{
    public List<UnitInfo> normalUnits;
    public List<UnitInfo> eliteUnits;
    public UnitSO boss;
}
