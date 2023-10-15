using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnit : UnitPassiveType
{
    public int spawnCount;
    public UnitSO unit;

    public override void Passive()
    {
        UnitManager.Instance.SpawnUnit(unit.unitType, unit.unitName, controller.transform.position);
    }
}
