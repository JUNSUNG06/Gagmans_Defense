using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/BuildingDataSO")]
public class BuildingDataSO : ScriptableObject
{
    public float maxBuildingHp;
    public int currentBuildingLevel;
    public int minBuildingLevel;
    public int maxBuildingLevel;
}
