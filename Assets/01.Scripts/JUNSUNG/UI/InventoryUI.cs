using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUI : GameUI
{
    private PlayerInventory inventory;

    private List<ItemSlot> slotList;

    public InventoryUI(TemplateContainer container) : base(container)
    {
        inventory = TestPlayer.Instance.GetComponent<PlayerInventory>();

        slotList = root.Query<ItemSlot>().ToList();
        Debug.Log(slotList.Count);
    }

    public override void Show()
    {
        base.Show();
        SetSlot(ItemType.Equipment, InvenSortType.Name);
    }

    private void SetSlot(ItemType itemType, InvenSortType sortType)
    {
        List<Item> items = inventory.GetSortInven(itemType, sortType);

        for(int i = 0; i < items.Count; i++)
        {
            slotList[i].SetItem(items[i]);
        }
    }
}
