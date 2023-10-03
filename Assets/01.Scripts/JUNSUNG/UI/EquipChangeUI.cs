using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EquipChangeUI : GameUI
{
    private List<ItemSlot> slotList;

    private int invenCount = 0;
    private EquipmentType selectEquipType;

    public EquipChangeUI(TemplateContainer _container) : base(_container)
    {
        container.name = "equip change";
        slotList = root.Query<ItemSlot>().ToList();

        foreach (var s in slotList)
        {
            s.RegisterCallback<ClickEvent>(e =>
            {
                Equipment item = s.GetItem() as Equipment;

                if (item == null)
                {
                    TestPlayer.Instance.Unit.Equipment.ReleaseEquipment(selectEquipType);
                }
                else
                {
                    TestPlayer.Instance.Unit.Equipment.ChangeEquipment(item);
                    PlayerInventory.Instance.RemoveItem(item);
                }

                TestPlayer.Instance.InvokeOnUnitSelectAction();

                Hide();
            });
        }
    }

    public void Show(List<Item> items)
    {
        Show();

        if(items.Count > 0)
        {
            selectEquipType = items[0].GetInfo<EquipmentSO>().equipType;
            SetSlot(items);
        }
        else
        {
            Reset();
        }
    }

    private void SetSlot(List<Item> items)
    {
        Reset();

        invenCount = items.Count;

        for (int i = 0; i < items.Count; i++)
        {
            slotList[i].SetItem(items[i]);
        }
    }

    private void Reset()
    {
        for (int i = 0; i < invenCount; i++)
            slotList[i].SetItem(null);
    }
}
