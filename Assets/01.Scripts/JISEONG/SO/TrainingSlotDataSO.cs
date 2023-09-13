using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/TrainingSlotDataSO")]
public class TrainingSlotDataSO : ScriptableObject
{
    public GameObject trainingUnit;
    public float trainingTime;
    public int trainingCost;
}
