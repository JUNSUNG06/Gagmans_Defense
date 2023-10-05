using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PubSlotSO")]
public class PubSlotSO : ScriptableObject
{
    public List<UnitSO> unitSOs;
    public int drawTime;

}
