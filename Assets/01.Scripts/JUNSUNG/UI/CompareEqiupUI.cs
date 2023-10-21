using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CompareEqiupUI : GameUI
{
    private Equipment currentEquip;
    private Equipment targetEquip;
    private List<SideLabel> labels;

    public CompareEqiupUI(TemplateContainer _container) : base(_container)
    {
        labels = root.Query<SideLabel>().ToList();
        container.style.width = root.style.width;
        container.style.height = root.style.height;

        foreach (StatusType t in Enum.GetValues(typeof(StatusType)))
        {
            labels[(int)t].SetRightText(t.ToString());
        }
    }

    public void Show(float x, float y, Equipment target, Equipment current)
    {
        if (target == null)
            return;
        Debug.Log(x);
        Debug.Log(y);
        
        container.style.left = new StyleLength(x);
        container.style.top = new StyleLength(y);

        targetEquip = target;
        currentEquip = current;

        foreach(StatusType t in Enum.GetValues(typeof(StatusType)))
        {
            SideLabel label = labels[(int)t];

            if(targetEquip != null)
            {
                int currentValue = targetEquip.GetInfo<EquipmentSO>().status.GetStat(t);
                int targetValue = currentEquip.GetInfo<EquipmentSO>().status.GetStat(t);
                CompareSign sign = currentValue > targetValue ? CompareSign.Greater : currentValue < targetValue ? CompareSign.Less : CompareSign.Equals;
                label.SetLeftText(currentValue.ToString(), sign);
            }
        }

        Show();
        Debug.Log('s');
    }

    public override void Show()
    {
        container.style.display = DisplayStyle.Flex;
        container.BringToFront();
    }

    public override void Hide()
    {
        container.style.display = DisplayStyle.None;
        Debug.Log('h');
    }
}
