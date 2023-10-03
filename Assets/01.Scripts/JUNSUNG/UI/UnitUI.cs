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
        EquipChangeUI ui = UIManager.Instance.UI[typeof(EquipChangeUI)] as EquipChangeUI;
        container.name = "unit";

        root.Q<ItemSlot>("helmetSlot").RegisterCallback<ClickEvent>(e =>
        {
            ui.Show(PlayerInventory.Instance.GetEqiuInvenByType(EquipmentType.Helmet));
        });

        root.Q<ItemSlot>("armorSlot").RegisterCallback<ClickEvent>(e =>
        {
            ui.Show(PlayerInventory.Instance.GetEqiuInvenByType(EquipmentType.Armor));
        });

        root.Q<ItemSlot>("backSlot").RegisterCallback<ClickEvent>(e =>
        {
            ui.Show(PlayerInventory.Instance.GetEqiuInvenByType(EquipmentType.Back));
        });

        root.Q<ItemSlot>("rightWeaponSlot").RegisterCallback<ClickEvent>(e =>
        {
            ui.Show(PlayerInventory.Instance.GetEqiuInvenByType(EquipmentType.RightWeapon));
        });

        root.Q<ItemSlot>("leftWeaponSlot").RegisterCallback<ClickEvent>(e =>
        {
            ui.Show(PlayerInventory.Instance.GetEqiuInvenByType(EquipmentType.LeftWeapon));
        });
    }

    public void Show(UnitController _controller)
    {
        foreach (EquipmentType type in Enum.GetValues(typeof(EquipmentType)))
        {
            slot[(int)type].SetItem(_controller.Equipment.GetEquip(type));
        }

        Show();
    }
}
