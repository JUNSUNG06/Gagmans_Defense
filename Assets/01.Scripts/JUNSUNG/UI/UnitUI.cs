using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class UnitUI : GameUI
{
    private List<ItemSlot> slot;

    public UnitUI(TemplateContainer container) : base(container)
    {
        slot = root.Query<ItemSlot>().ToList();
    }

    public override void Show()
    {
        base.Show();

        UnitEquipment equip = TestPlayer.Instance.Unit.GetComponent<UnitEquipment>();

        foreach(EquipmentType type in Enum.GetValues(typeof(EquipmentType))) 
        {
            slot[(int)type].SetItem(equip.GetEquip(type));
        }
    }
}
