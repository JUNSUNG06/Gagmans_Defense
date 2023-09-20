using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEquipment : UnitComponent
{
    private Dictionary<EquipmentType, Equipment> equipments = new Dictionary<EquipmentType, Equipment>();

    public override void Init()
    {
        base.Init();
    }

    public Equipment ChangeEquipment(Equipment equip)
    {
        Equipment beforeEquip = equipments.ContainsKey(equip.equipType) ? equipments[equip.equipType] : null;

        equipments[equip.equipType] = equip;

        return beforeEquip;
    }

    public Equipment ReleaseEquipment(EquipmentType type)
    {
        Equipment beforeEquip = equipments[type];
        equipments[type] = null;
        return beforeEquip;
    }
}
