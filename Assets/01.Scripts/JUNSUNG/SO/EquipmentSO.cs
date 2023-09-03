using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/EquipmentSO")]
public class EquipmentSO : ScriptableObject
{
    public StatusSO status;
    public Sprite sprite;
    public EquipmentType type;
    public string equipName;
}