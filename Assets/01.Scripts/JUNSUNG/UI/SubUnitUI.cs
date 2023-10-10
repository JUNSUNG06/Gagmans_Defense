using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UIElements;

public class SubUnitUI : GameUI
{
    private List<Label> labelList = new List<Label>();

    public SubUnitUI(TemplateContainer _container) : base(_container)
    {
        foreach(var stat in Enum.GetValues(typeof(StatusType)))
        {
            labelList.Add(root.Q<Label>($"{stat}Label"));
        }
    }

    public void Show(UnitController unit)
    {
        foreach (StatusType stat in Enum.GetValues(typeof(StatusType)))
        {
            labelList[(int)stat].text = $"{stat} : {unit.Stat.GetStatus(stat)}";
        }

        Show();
    }

    public override void Show()
    {
        container.style.display = DisplayStyle.Flex;
    }
}
