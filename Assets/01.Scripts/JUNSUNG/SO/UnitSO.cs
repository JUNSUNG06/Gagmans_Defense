using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/UnitSO")]
public class UnitSO : ScriptableObject
{
    public string unitName;
    public GameObject unit;
    public StatusSO status;
}
