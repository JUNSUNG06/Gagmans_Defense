using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEquipment : MonoBehaviour
{
    private Dictionary<EquipmentType, Equipment> equipments = new Dictionary<EquipmentType, Equipment>();

    public Equipment ChangeEquipment(Equipment equip)
    {
        if(equipments.ContainsKey(equip.type))
        {
            Equipment beforeEquip = equipments[equip.type];
            equipments[equip.type] = equip;

            return beforeEquip;
        }

        return null;
    }

    public Equipment ReleaseEquipment(EquipmentType type)
    {
        Equipment beforeEquip = equipments[type];
        equipments[type] = null;
        return beforeEquip;
    }
}
