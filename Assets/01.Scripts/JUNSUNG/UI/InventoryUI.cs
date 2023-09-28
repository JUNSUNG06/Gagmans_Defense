using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUI : GameUI
{
    private PlayerInventory inventory;

    private List<VisualElement> slotList;

    public InventoryUI(TemplateContainer container) : base(container)
    {
        inventory = TestPlayer.Instance.GetComponent<PlayerInventory>();

        slotList = root.Query<VisualElement>(className: "i_slot").ToList();
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
            slotList[i].Q("image").style.backgroundImage = new StyleBackground(items[i].Info.image);
        }
    }
}
