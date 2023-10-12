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
        PlayerManager testPlayer = PlayerManager.Instance;

        foreach (var s in slotList)
        {
            s.RegisterCallback<ClickEvent>(e =>
            {
                Equipment item = s.GetItem() as Equipment;

                if (item == null)
                {
                    testPlayer.Unit.Equipment.ReleaseEquipment(selectEquipType);
                }
                else
                {
                    testPlayer.Unit.Equipment.ChangeEquipment(item);
                    PlayerInventory.Instance.RemoveItem(item);
                }

                UIManager.Instance.GetUI<UnitUI>().Show(testPlayer.Unit);
                testPlayer.InvokeOnUnitSelectAction();

                Hide();
            });
        }
    }

    public void Show(EquipmentType type)
    {
        Show();

        List<Item> items = PlayerInventory.Instance.GetEqiuInvenByType(type);
        selectEquipType = type;

        if (items.Count > 0)
        {
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
