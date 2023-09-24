using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class UnitEquipment : UnitComponent
{
    private Dictionary<EquipmentType, Equipment> equipments = new Dictionary<EquipmentType, Equipment>();

    public Action<EquipmentType, Sprite, Direction> OnEquipChageVisual { get; set; }
    public UnityEvent<StatusSO, bool> OnEquipChageStatus;

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

        if (Input.GetKeyDown(KeyCode.R))
        {
            ReleaseEquipment(EquipmentType.Helmet);
        }
    }

    public Equipment ChangeEquipment(Equipment equip, Direction dir)
    {
        EquipmentSO info = equip.GetInfo<EquipmentSO>();

        Equipment beforeEquip = equipments.ContainsKey(info.equipType) ? equipments[info.equipType] : null;

        equipments[info.equipType] = equip;

        if(beforeEquip != null)
            OnEquipChageStatus?.Invoke(beforeEquip.GetInfo<EquipmentSO>().status, false);
        OnEquipChageStatus?.Invoke(info.status, true);

        OnEquipChageVisual?.Invoke(info.equipType, info.image, dir);

        return beforeEquip;
    }

    public Equipment ReleaseEquipment(EquipmentType type)
    {
        if (!equipments.ContainsKey(type) || equipments[type] == null)
            return null;

        Equipment beforeEquip = equipments[type];

        equipments[type] = null;

        OnEquipChageStatus?.Invoke(beforeEquip.GetInfo<EquipmentSO>().status, false);

        OnEquipChageVisual?.Invoke(type, null, Direction.None);

        return beforeEquip;
    }
}
