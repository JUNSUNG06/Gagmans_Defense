using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UI.CanvasScaler;

public class UnitUI : GameUI
{
    private List<ItemSlot> slot;
    private List<Label> labelList = new List<Label>();

    public UnitUI(TemplateContainer container) : base(container)
    {
        slot = root.Query<ItemSlot>().ToList();
        EquipChangeUI ui = UIManager.Instance.GetUI<EquipChangeUI>();
        container.name = "unit";

        foreach(EquipmentType t in Enum.GetValues(typeof(EquipmentType)))
        {
            ItemSlot s = root.Q<ItemSlot>($"{t}Slot");

            s.RegisterCallback<ClickEvent>(e =>
            {
                ui.Show(s.GetItem() as Equipment, t);
            });
        }

        foreach (var stat in Enum.GetValues(typeof(StatusType)))
        {
            labelList.Add(root.Q<Label>($"{stat}Label"));
        }
    }

    public void Show(UnitController _controller)
    {
        foreach (StatusType stat in Enum.GetValues(typeof(StatusType)))
        {
            labelList[(int)stat].text = $"{stat} : {_controller.Stat.GetStatus(stat)}";
        }

        foreach (EquipmentType type in Enum.GetValues(typeof(EquipmentType)))
        {
            slot[(int)type].SetItem(_controller.Equipment.GetEquip(type));
        }

        Show();
    }
}
