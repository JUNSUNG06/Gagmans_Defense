using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PubUI : GameUI
{
    private List<VisualElement> slotList;
    public PubUI(TemplateContainer container) : base(container)
    {
        container.name = "pub";
        slotList = root.Query("Slot").ToList();
    }

    public void SettingTimer(int index, int time)
    {
        slotList[index].Q<ProgressBar>("timer").title = $"{(time / 60)}:{time % 60}";
    }

    public void SettingSlot(int index, int cost)
    {
        slotList[index].Q<Button>("buyBtn").RegisterCallback<ClickEvent>(Test);
        slotList[index].Q<Button>("buyBtn").text = cost.ToString();
        //slotList[index].Q<VisualElement>("image").style.backgroundImage = image; //이미지 어떻게 바꿀지 물어봐야함
    }
    public void Test(ClickEvent e)
    {

    }
}
