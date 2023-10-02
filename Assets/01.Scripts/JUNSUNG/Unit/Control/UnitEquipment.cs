using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class UnitEquipment : UnitComponent
{
    private Dictionary<EquipmentType, Equipment> equipments = new Dictionary<EquipmentType, Equipment>();

    public Action<EquipmentType, Sprite> OnEquipChageVisual { get; set; }
    public UnityEvent<StatusSO, bool> OnEquipChageStatus;

    public SPUM_SpriteList spriteList;

    public override void Init(UnitController _controller)
    {
        base.Init(_controller);

        spriteList = transform.Find("Visual/UnitRoot/Root").GetComponent<SPUM_SpriteList>();
        spriteList.Init(controller);

        foreach (var startingEquip in controller.info.startingEquips)
        {
            ChangeEquipment(new Equipment(ItemType.Equipment, startingEquip.name, startingEquip.type));
        }
    }

    protected override void UnitUpdate()
    {
        //테스트 코드
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            ChangeEquipment(new Equipment(ItemType.Equipment, "Test_Helmet", EquipmentType.Helmet));
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ReleaseEquipment(EquipmentType.Helmet);
        }
    }

    public Equipment GetEquip(EquipmentType type)
    {
        if (equipments.TryGetValue(type, out Equipment equip))
            return equipments[type];
        else
            return null;
    }

    public Equipment ChangeEquipment(Equipment equip)
    {
        EquipmentSO info = equip.Info as EquipmentSO;

        Equipment beforeEquip = equipments.ContainsKey(info.equipType) ? equipments[info.equipType] : null;

        equipments[info.equipType] = equip;

        if(beforeEquip != null)
            OnEquipChageStatus?.Invoke(((EquipmentSO)beforeEquip.Info).status, false);
        OnEquipChageStatus?.Invoke(info.status, true);

        OnEquipChageVisual?.Invoke(info.equipType, info.image);

        return beforeEquip;
    }

    public Equipment ReleaseEquipment(EquipmentType type)
    {
        if (!equipments.ContainsKey(type) || equipments[type] == null)
            return null;

        Equipment beforeEquip = equipments[type];

        equipments[type] = null;

        OnEquipChageStatus?.Invoke(((EquipmentSO)beforeEquip.Info).status, false);

        OnEquipChageVisual?.Invoke(type, null);

        return beforeEquip;
    }
}
