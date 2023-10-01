using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/UnitListSO")]
public class UnitListSO : ScriptableObject
{
    public List<UnitSO> units;

    public UnitSO GetUnit(string name)
    {
        return units.Find(x => x.unitName == name);
    }
}
