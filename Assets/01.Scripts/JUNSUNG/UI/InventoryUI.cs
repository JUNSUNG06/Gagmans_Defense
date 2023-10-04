using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUI : GameUI
{

    private List<ItemSlot> slotList;

    private int invenCount = 0;
    private EquipmentType selectEquipType;

    public InventoryUI(TemplateContainer container) : base(container)
    {
        container.name = "inventory";
        slotList = root.Query<ItemSlot>().ToList();
    }

    public void Show(List<Item> items)
    {
        Show();
        selectEquipType = items[0].GetInfo<EquipmentSO>().equipType;
        SetSlot(items);
    }

    public override void Show()
    {
        base.Show();
        SetSlot(PlayerInventory.Instance.GetSortInven(ItemType.Equipment, InvenSortType.Name));
    }

    private void SetSlot(List<Item> items)
    {
        Reset();

        invenCount = items.Count;

        for(int i = 0; i < items.Count; i++)
        {
            slotList[i].SetItem(items[i]);
        }
    }

    private void Reset()
    {
        for(int i = 0; i < invenCount; i++)
            slotList[i].SetItem(null);
    }
}
