using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitEquipment : UnitComponent
{
    private Dictionary<EquipmentType, Equipment> equipments = new Dictionary<EquipmentType, Equipment>();

    public Action<Equipment, Direction> OnEquipChage;

    public override void Init(UnitController _controller)
    {
        base.Init(_controller);
    }

    protected override void UnitUpdate()
    {
        //테스트 코드
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            ChangeEquipment(new Equipment(ItemType.Equipment, "Test_Helmet", EquipmentType.Helmet), Direction.None);
        }
    }

    public Equipment ChangeEquipment(Equipment equip, Direction dir)
    {
        Equipment beforeEquip = equipments.ContainsKey(equip.equipType) ? equipments[equip.equipType] : null;

        equipments[equip.equipType] = equip;
        OnEquipChage?.Invoke(equip, dir);

        return beforeEquip;
    }

    public Equipment ReleaseEquipment(EquipmentType type)
    {
        Equipment beforeEquip = equipments[type];
        equipments[type] = null;
        OnEquipChage?.Invoke(null, Direction.None);
        return beforeEquip;
    }
}
